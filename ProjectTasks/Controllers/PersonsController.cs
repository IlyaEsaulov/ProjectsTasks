using ProjectTasks.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectTasks.Controllers
{
    public class PersonsController
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ProjectTasks"].ConnectionString;

        public object PersonsList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("select *from Persons", connection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public string GetPerson(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string data = "";
            connection.Open();
            SqlCommand sqlData = new SqlCommand("select *from Persons where id="+Id+"", connection);
            SqlDataReader dataReader = sqlData.ExecuteReader();
            while (dataReader.Read())
            {
                data = ""+dataReader.GetInt32(0)+" "+dataReader.GetString(1)+ " " + dataReader.GetString(2) + " " + dataReader.GetString(3) + "";
            }
            connection.Close();
            return data;
        }

        public void Add(Persons persons)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand("InsertOrUpdatePerson", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value ="insert";
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = persons.Name;
                sqlCommand.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = persons.Surname;
                sqlCommand.Parameters.Add("@Fathername", SqlDbType.NVarChar).Value = persons.Fathername;

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
        }

        public void Update(Persons persons)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand("InsertOrUpdatePerson", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = "update";
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = persons.Id;
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = persons.Name;
                sqlCommand.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = persons.Surname;
                sqlCommand.Parameters.Add("@Fathername", SqlDbType.NVarChar).Value = persons.Fathername;

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
        }

        public void Delete(Persons persons)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand("InsertOrUpdatePerson", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = "delete";
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = persons.Id;

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