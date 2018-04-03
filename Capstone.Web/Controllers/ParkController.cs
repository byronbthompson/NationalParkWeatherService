using Capstone.Web.Models;
using Capstone.Web.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParkController : BaseController
    {
        IParkDAL _parkDAL;
        IWeatherDAL _weatherDAL;

        /// <summary>
        /// Instantiates ParkController with access to the ParkDAL and WeatherDAL 
        /// </summary>
        /// <param name="parkDAL">CRUD methods for Park</param>
        /// <param name="weatherDAL"> CRUD methods for Weather</param>
        public ParkController(IParkDAL parkDAL, IWeatherDAL weatherDAL)
        {
            this._parkDAL = parkDAL;
            this._weatherDAL = weatherDAL;
        }

        /// <summary>
        /// Home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // Get all parks from DB
            IList<Park> parks = _parkDAL.GetAllParks();

            return View("Index", parks);
        }

        /// <summary>
        /// Detail View of Parks with 5 Day weather forecast
        /// </summary>
        /// <param name="id">Park.ParkCode to GET that park upon Click()</param>
        /// <returns>Detail View</returns>
        public ActionResult Detail(string id)
        {
            // If no park was clicked then return to index page
            if (id == null)
            {
                return RedirectToAction("Index", "Park");
            }

            //Gets current Temp unit to work with in View
            string tempUnit = GetCurrentTempUnit();

            //Get park by param: id
            Park park = _parkDAL.GetPark(id);
            List<Weather> weather = _weatherDAL.GetWeatherByParkCode(id);
            ParkWeather pw = new ParkWeather()
            {
                Park = park,
                Weather = weather,
                TempUnit = tempUnit
            };

            return View("Detail", pw);
        }

        /// <summary>
        /// Performs Temp COnversion when user Clicks radio button
        /// </summary>
        /// <param name="fOrC">Holds Form input value of "f" or "c" representing celsius and fahrenheit</param>
        /// <param name="id">Park id to pass back to the view thru RedirectToAction</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TempConversion(string fOrC, string id)
        {
            string parkCode = id;
            Session["TempUnit"] = fOrC;
            return RedirectToAction("Detail", "Park", new { id = parkCode });
        }

    }
}