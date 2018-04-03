using Capstone.Web.Models;
using Capstone.Web.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : BaseController
    {
        ISurveyDAL _surveyDAL;
        IParkDAL _parkDAL;

        /// <summary>
        /// Instantiates an instance of Survey with dependency injection 
        /// </summary>
        /// <param name="surveyDAL">Access to DAL and methods for Survey DB </param>
        /// <param name="parkDAL">Access to DAL and methods pertaining to park</param>
        public SurveyController(ISurveyDAL surveyDAL, IParkDAL parkDAL)
        {
            this._surveyDAL = surveyDAL;
            this._parkDAL = parkDAL;
        }
 
        /// <summary>
        /// Survey Index page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Park> parks = _parkDAL.GetAllParks();

            //Select List For Park names and Code
            List<SelectListItem> parkItems = new List<SelectListItem>();

            // Makes a new List of only Park.Name to use for the form drop
            foreach(Park p in parks)
            {
                parkItems.Add(new SelectListItem { Text = p.ParkName, Value = p.ParkCode });
            }

            //Put SelectLsit in TempData to access in the View
            TempData["Parks"] = parkItems;

            //Select List For State
            TempData["States"] = States;

            //Select List For Activity Level
            TempData["ActivityLevel"] = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Extremely Active", Value = "extremelyActive"},
                    new SelectListItem { Text = "Active", Value = "active"},
                    new SelectListItem { Text = "Sedentary", Value = "sedentary"},
                    new SelectListItem { Text = "Inactive", Value = "inactive"}
                };

            return View("Index");
        }

        /// <summary>
        /// Method: POST for Survey form
        /// </summary>
        /// <param name="survey">Survey Model</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(Survey survey)
        {
            //Check to see if survey was successfully added to the DB
            bool surveyAdded = _surveyDAL.AddSurvey(survey.ParkCode, survey.Email, survey.State, survey.ActivityLevel);

            if (!surveyAdded)
            {
                return View("Index");
            }

            return RedirectToAction("SurveyResults", "Survey");
        }

        //Disply Survey results
        public ActionResult SurveyResults()
        {
            List<Result> results = _surveyDAL.GetSurveyResults();
          
            return View("SurveyResults", results);
        }

        

    }
}