using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private readonly string connectionString;
        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT survey_result VALUES(@parkCode, @emailAddress, @state, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public IList<SurveyResults> GetSurveys()
        {
            IList<SurveyResults> surveyResults = new List<SurveyResults>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT parkCode, park.parkName, COUNT(*) AS count FROM survey_result INNER JOIN park ON survey_result.parkCode = park.parkCode GROUP BY parkCode;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResults survey = new SurveyResults()
                        {
                            ParkName = Convert.ToString(reader["park.parkName"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            Count = Convert.ToInt32(reader["count"]),
                        };

                        surveyResults.Add(survey);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return surveyResults;
        }
    }
}
