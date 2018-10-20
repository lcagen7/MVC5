using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC5.Services
{
    public class DataAccess
    {
        public List<Assessment> GetAllAssessments()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentConnection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("Select * From Assessment", sqlConnection);
            List<Assessment> assessmentList = new List<Assessment>();
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var assessment = new Assessment
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            NumberOfQuestions = (int)reader["NumberOfQuestions"],
                            AssessmentType = (AssessmentType)reader["AssessmentType"]
                        };
                        assessmentList.Add(assessment);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR | MVC5.Services.DataAccess.GetAssessments | " + ex.StackTrace);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            return assessmentList;
        }

        public Assessment GetDetailsById(Int32 Id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentConnection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("Select * From Assessment Where Id=" + Id, sqlConnection);
            Assessment assessment = null;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        assessment = new Assessment
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            NumberOfQuestions = (int)reader["NumberOfQuestions"],
                            AssessmentType = (AssessmentType)reader["AssessmentType"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR | MVC5.Services.DataAccess.GetDetailsById | Id:" + Id + " | " + ex.StackTrace);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            return assessment;
        }

        public Int32 EditDetailsById(Assessment assessment)
        {
            Int32 numberOfRecordsUpdated = 0;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentConnection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand($"Update Assessment Set Name=@name, Description=@description, NumberOfQuestions=@numberOfQuestions Where Id=@id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", assessment.Id);
            sqlCommand.Parameters.AddWithValue("@name", assessment.Name);
            sqlCommand.Parameters.AddWithValue("@description", assessment.Description);
            sqlCommand.Parameters.AddWithValue("@numberOfQuestions", assessment.NumberOfQuestions);
            try
            {
                sqlConnection.Open();
                numberOfRecordsUpdated = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR | MVC5.Services.DataAccess.EditDetailsById | Id:" + assessment.Id + " | " + ex.StackTrace);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            return numberOfRecordsUpdated;
        }

        public Int32 CreateAssessment(Assessment assessment)
        {
            Int32 numberOfRecordsUpdated = 0;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentConnection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand($"Insert Into Assessment (Name, Description, NumberOfQuestions, AssessmentType) Values(@name, @description, @numberOfQuestions, @assessmentType)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", assessment.Name);
            sqlCommand.Parameters.AddWithValue("@description", assessment.Description);
            sqlCommand.Parameters.AddWithValue("@numberOfQuestions", assessment.NumberOfQuestions);
            sqlCommand.Parameters.AddWithValue("@assessmentType", (int)assessment.AssessmentType);
            try
            {
                sqlConnection.Open();
                numberOfRecordsUpdated = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR | MVC5.Services.DataAccess.EditDetailsById | Id:" + assessment.Id + " | " + ex.StackTrace);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            return numberOfRecordsUpdated;
        }

        public Int32 DeleteAssessment(Int32 id)
        {
            Int32 numberOfRecordsUpdated = 0;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentConnection"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand($"Delete From Assessment where Id = {id}", sqlConnection);
            try
            {
                sqlConnection.Open();
                numberOfRecordsUpdated = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR | MVC5.Services.DataAccess.DeleteAssessment | Id:" + id + " | " + ex.StackTrace);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            return numberOfRecordsUpdated;
        }
    }
}