using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.Models.DAL
{
    public class WeatherSQLDAL : IWeatherDAL
    {
        string connectionString = null;

        public WeatherSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetWeatherByParkCode(string parkCode)
        {
            List<Weather> parkWeather = new List<Weather>();
            string GetWeatherSQL = "SELECT * FROM weather WHERE parkCode = @parkCode";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(GetWeatherSQL, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        parkWeather.Add(GetWeatherFromReader(reader));
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return parkWeather;
        }


        private Weather GetWeatherFromReader(SqlDataReader reader)
        {
            Weather parkWeather = new Weather()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                Low = Convert.ToInt32(reader["low"]),
                High = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };
            return parkWeather;      
        }

    }
}