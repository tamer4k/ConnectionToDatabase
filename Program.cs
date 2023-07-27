using System;
using System.Data.SqlClient;
using System.Text;

namespace ConnectionToDatabase1
{
    class Program
    {
        static void Main(string[] args)
        {
            var datasource = @"(localdb)\MSSQLLocalDB";//your server
            var database = "test"; //your database name
            var username = ""; //username of server to connect
            var password = ""; //password
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
            + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;



            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    Console.WriteLine("Openning Connection ...");

                    //open connection
                    conn.Open();

                    Console.WriteLine("Connection successful!");

                    //create a new SQL Query using StringBuilder
                    StringBuilder strBuilder = new StringBuilder();
                    Console.WriteLine("Wat is je naam?");
                    string insert1 = Console.ReadLine();
                    strBuilder.Append("INSERT INTO student (fname, lname, gender) VALUES ");
                    strBuilder.Append($"('{insert1}', N'console',N'male'),");
                    strBuilder.Append("('insert2', N'console',N'female')");

                    string sqlQuery = strBuilder.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
                    {
                        command.ExecuteNonQuery(); //execute the Query
                        Console.WriteLine("Query Executed.");
                    }
                    strBuilder.Clear(); // clear all the string

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            Console.Read();
        }
    }
}
