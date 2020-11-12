using SchedulerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SchedulerApp.Data
{
    internal class AdminDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsherSignUp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //performs all operations on the database.
        public List<AdminModel> FetchAll()
        {
            List<AdminModel> returnList = new List<AdminModel>();

            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.ServiceDetail";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AdminModel user = new AdminModel();
                        user.Id = reader.GetInt32(0);
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);
                        user.Date = reader.GetDateTime(3);
                        user.Duties = reader.GetString(4);
                        user.Service = reader.GetInt32(5);
                        user.UserID = reader.GetString(6);

                        returnList.Add(user);
                    }
                }
            }

            return returnList;
        }

        public AdminModel FetchOne(int Id)
        {
            AdminModel user = new AdminModel();

            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.ServiceDetail where Id = @id";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                //associate @id with Id parameter 
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);
                        user.Date = reader.GetDateTime(3);
                        user.Duties = reader.GetString(4);
                        user.Service = reader.GetInt32(5);
                        user.UserID = reader.GetString(6);
                    }
                }
                return user;
            }
        }

        // Delete a record in the database
        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "delete from dbo.ServiceDetail where Id = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                //associate @fields with field parameters 
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = id;

                connection.Open();

                int deletedID = command.ExecuteNonQuery();

                return deletedID;
            }
        }

        // Create a new record in the database
        public int CreateOrUpdate(AdminModel adminModel)
        {
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if (adminModel.Id <= 0)
                {
                    //If adminModel.id <= 1 then create new record in database
                    sqlQuery = "insert into dbo.ServiceDetail Values(@FirstName, @LastName, @Date, @Duties, @Service, @UserId)";
                }
                else
                {
                    //If adminModel.id > 1 then update record in database
                    sqlQuery = "update dbo.ServiceDetail set FirstName = @FirstName, LastName = @LastName, Date = @Date, Duties = @Duties, Service = @Service, UserID = @UserID where Id = @Id where the Id = @Id";
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                //associate @fields with field parameters 
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 10).Value = adminModel.Id;
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar, 1000).Value = adminModel.FirstName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar, 1000).Value = adminModel.LastName;
                command.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = adminModel.Date;
                command.Parameters.Add("@Duties", System.Data.SqlDbType.VarChar, 1000).Value = adminModel.Duties;
                command.Parameters.Add("@Service", System.Data.SqlDbType.Char, 1).Value = adminModel.Service;
                command.Parameters.Add("@UserId", System.Data.SqlDbType.VarChar, 1000).Value = adminModel.UserID;

                connection.Open();

                int newID = command.ExecuteNonQuery();
               //command.ExecuteNonQuery();

                return newID;
            }
        }
    }
}