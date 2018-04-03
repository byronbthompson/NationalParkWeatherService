using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.Models.DAL
{
    public class SurveySQLDAL : ISurveyDAL
    {
        string _connectionString = null;

        public SurveySQLDAL(string connectionString)
        {
            this._connectionString = connectionString;
        }

        //Create Survey per user input on Survey/Index.cshtml
        public bool AddSurvey(string parkCode, string email, string state, string activityLevel)
        {
            string sqlCreateSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel)" +
                                        " VALUES (@parkCode, @email, @state, @activityLevel);";

            bool wasAdded =false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlCreateSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@activityLevel", activityLevel);

                    wasAdded = cmd.ExecuteNonQuery() == 1 ? true : false;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }

            return wasAdded;
        }

        public List<Result> GetSurveyResults()
        {
            string sqlGetSurvey = "SELECT COUNT(survey_result.parkCode) AS SurveyCount, park.parkName, park.parkCode, " +
                "park.inspirationalQuote, park.inspirationalQuoteSource FROM survey_result " +
                "JOIN park on park.parkCode = survey_result.parkCode Group by park.parkName, park.parkCode, park.inspirationalQuote, " +
                "park.inspirationalQuoteSource Order by SurveyCount DESC, park.parkName";


            List<Result> surveyResults = new List<Result>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetSurvey, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        surveyResults.Add(MapSurveyViewModelFromReader(reader));
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }

            return surveyResults;
        }

        // Data Mapping for Survey
        private Survey MapSurveyFromReader(SqlDataReader reader)
        {
            return new Survey()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                Email = Convert.ToString(reader["email"]),
                State = Convert.ToString(reader["state"]),
                ActivityLevel = Convert.ToString(reader["activityLevel"])
            };
        }

        //Data Mapping for SurveyViewModel
        private Result MapSurveyViewModelFromReader(SqlDataReader reader)
        {
            return new Result()
            {
                VoteCount = Convert.ToInt32(reader["SurveyCount"]),
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
            };
        }
    }
}