using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.Models.DAL;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class ControllerTests
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ParkWeatherGeek;Integrated Security = True";
        IParkDAL parkDAL = new ParkSQLDAL(connectionString);
        IWeatherDAL weatherDAL = new WeatherSQLDAL(connectionString);
        ISurveyDAL surveyDAL = new SurveySQLDAL(connectionString);

        [TestMethod()]
        public void HomeController()
        {
            //PArk controller test
            var controller = new ParkController(parkDAL, weatherDAL);

            //Index Action should return index view
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod()]
        public void SurveyController()
        {
            //Survey controller test
            var sC = new SurveyController(surveyDAL, parkDAL);
            
            //Index Action should return index view
            var index = sC.Index() as ViewResult;
            Assert.AreEqual("Index", index.ViewName);

            //SurveyResults action should return Surveyresults
            var surveyResult = sC.SurveyResults() as ViewResult;
            Assert.AreEqual("SurveyResults", surveyResult.ViewName);
        }
    }
}