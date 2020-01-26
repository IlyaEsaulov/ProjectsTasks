using ProjectTasks.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjectTasks.Controllers
{
    public class TasksControllers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ProjectTasks"].ConnectionString;

        public object TaskList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("select *from TableTasksAndPerson", connection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public IEnumerable<Persons> PersonDataView()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sqlData = new SqlCommand("select *from persons", connection);
            SqlDataReader dataReader = sqlData.ExecuteReader();
            while (dataReader.Read())
            {
                var person = new Persons
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Name = dataReader["Name"].ToString(),
                    Surname = dataReader["Surname"].ToString(),
                    Fathername = dataReader["Fathername"].ToString()
                };
               yield return person;
            }
            connection.Close();
        }

        public string GetTask(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string data = "";
            connection.Open();
            SqlCommand sqlData = new SqlCommand("select *from Tasks where id=" + Id + "", connection);
            SqlDataReader dataReader = sqlData.ExecuteReader();
            while (dataReader.Read())
            {
                data = "" + dataReader.GetInt32(0) 
                    + "|" + dataReader.GetString(1) + "|" 
                    + dataReader.GetInt32(2) + "|" 
                    + dataReader.GetDateTime(3) + "|"
                    + dataReader.GetDateTime(4) + "|"
                    + dataReader.GetString(5) + "|"
                    + dataReader.GetInt32(6) + "";
            }
            connection.Close();

            return data;
        }

        public void Add(Tasks tasks)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand("InsertOrUpdateOrDeleteTask", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = "insert";
                sqlCommand.Parameters.Add("@Title", SqlDbType.NVarChar).Value = tasks.Title;
                sqlCommand.Parameters.Add("@Workload", SqlDbType.Int).Value = tasks.Workload;
                sqlCommand.Parameters.Add("@DateStart", SqlDbType.Date).Value = tasks.DateStart;
                sqlCommand.Parameters.Add("@DateFinish", SqlDbType.Date).Value = tasks.DateFinish;
                sqlCommand.Parameters.Add("@Status", SqlDbType.NVarChar).Value = tasks.Status;
                sqlCommand.Parameters.Add("@IdPerson", SqlDbType.Int).Value = tasks.IdPerson;

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
        }

        public void Update(Tasks tasks)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand("InsertOrUpdateOrDeleteTask", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = "update";
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = tasks.Id;
                sqlCommand.Parameters.Add("@Title", SqlDbType.NVarChar).Value = tasks.Title;
                sqlCommand.Parameters.Add("@Workload", SqlDbType.Int).Value = tasks.Workload;
                sqlCommand.Parameters.Add("@DateStart", SqlDbType.Date).Value = tasks.DateStart;
                sqlCommand.Parameters.Add("@DateFinish", SqlDbType.Date).Value = tasks.DateFinish;
                sqlCommand.Parameters.Add("@Status", SqlDbType.NVarChar).Value = tasks.Status;
                sqlCommand.Parameters.Add("@IdPerson", SqlDbType.Int).Value = tasks.IdPerson;


                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
        }

        public void Delete(Tasks tasks)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand("InsertOrUpdateOrDeleteTask", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = "delete";
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = tasks.Id;

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
        }
    }
}