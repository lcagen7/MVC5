using API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AssessmentController : ApiController
    {
        public HttpResponseMessage GetAllAssessments()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentConnection"].ConnectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Select * From Assessment", connection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Assessment> assessmentList = new List<Assessment>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var assessment = new Assessment();

                    assessment.Id = (int)reader["Id"];
                    assessment.Name = reader["Name"].ToString();
                    assessment.Description = reader["Description"].ToString();
                    assessment.NumberOfQuestions = (int)reader["NumberOfQuestions"];
                    assessment.AssessmentType = (AssessmentType)reader["AssessmentType"];

                    assessmentList.Add(assessment);
                }
            }

            reader.Close();
            connection.Close();
            return Request.CreateResponse(HttpStatusCode.OK, assessmentList);
        }
    }
}
