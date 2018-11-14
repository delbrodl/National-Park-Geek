using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private readonly string connectionString;
        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Weather> GetWeather(string parkCode)
        {
            IList<Weather> fiveDayWeather = new List<Weather>();
            

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather w = new Weather();
                        {
                            w.ParkCode = Convert.ToString(reader["parkCode"]);
                            w.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
                            w.Low = Convert.ToInt32(reader["low"]);
                            w.High = Convert.ToInt32(reader["high"]);
                            w.Forecast = Convert.ToString(reader["forecast"]);
                        };
                        fiveDayWeather.Add(w);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return fiveDayWeather;
        }
    }
}
