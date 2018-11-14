using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private readonly string connectionString;
        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Park> GetAllParks()
        {
            IList<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT parkCode, parkName, state, parkDescription FROM park ORDER BY parkName ASC;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park p = new Park()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            Name = Convert.ToString(reader["parkName"]),
                            Location = Convert.ToString(reader["state"]),
                            Description = Convert.ToString(reader["parkDescription"])
                        };
                        parks.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return parks;
        }

        public ParkDetail GetParkDetails(string parkCode)
        {
            ParkDetail p = new ParkDetail();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkCode = @parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.Name = Convert.ToString(reader["parkName"]);
                        p.Location = Convert.ToString(reader["state"]);
                        p.Description = Convert.ToString(reader["parkDescription"]);
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        p.NumOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        p.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        p.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.NumOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return p;
        }
    }
}
