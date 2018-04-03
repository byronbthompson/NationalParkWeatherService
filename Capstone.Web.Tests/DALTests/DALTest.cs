using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using Capstone.Web.Models.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Tests
{
    [TestClass]
    public class DALTest
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ParkWeatherGeek;Integrated Security = True";
        private int rowsAffected = 0;

        [TestInitialize]
        public void Initialize()
        {
            SqlCommand cmd;
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd = new SqlCommand("INSERT INTO survey_result(parkCode, emailAddress, state, activityLevel)" +
                                        " VALUES ('enp', 'byront@gmail.com', 'ohio', 'active')", conn);
                rowsAffected = cmd.ExecuteNonQuery();

            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetSurveyTest()
        {
            SurveySQLDAL dal = new SurveySQLDAL(connectionString);
            List<Result> surveyResults = dal.GetSurveyResults();
            Assert.AreNotEqual(0,surveyResults.Count);

        }

        [TestMethod]
        public void AddSurvey()
        {
            //Added survey in [TestInitialize]
            Assert.AreEqual(1, rowsAffected);
        }
    }
}
