using SchedulerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace SchedulerApp.Services.Data
{
    public class SecurityDAO
    {
        // Connect to database
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsherSignUp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        internal bool FindByUser(UserModel user)
        {
            bool success = false;

            //Prepaired statements
            //SQL query expression for selecting if there is a user with the correct fields.
            string queryString = "select * from dbo.Users where username = @Username and password = @password";

            //create and open the connection to the database inside a using block.
            // This ensures all resources are closed.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // create the command and parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);
                //associate the @Username with user.Username
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                //associate the @Password with user.Password
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                //open the database and run the command.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }
    }
}