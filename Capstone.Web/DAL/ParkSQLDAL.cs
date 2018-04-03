using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models.DAL
{
    public class ParkSQLDAL : IParkDAL
    {
        string connectionString = null;

        public ParkSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();
            string GetAllParksSQL = "SELECT * FROM Park";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand( GetAllParksSQL, conn );
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    parks.Add(GetParkFromReader(reader));
                }
            }

            return parks;
        }

        public Park GetPark(string parkCode)
        {
            Park park = new Park();
            string getParkByCodeSQL = "SELECT * FROM Park WHERE parkCode = @parkCode";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getParkByCodeSQL, conn);
                cmd.Parameters.AddWithValue("@parkCode", parkCode);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    park = GetParkFromReader(reader);
                }
            }

            return park;

        }

        private Park GetParkFromReader(SqlDataReader reader)
        {
            Park park = new Park()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToSingle(reader["milesOfTrail"]),
                NumberOfCampSites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]),
            };
            return park;
        }
    }

}