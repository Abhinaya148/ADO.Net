using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class DataReader
    {
        static string connectionString = @"Data Source=ICS-LT-G7T61F3\SQLEXPRESS01;Initial Catalog=AdventureWorks2022;Integrated Security=True";
        public static void GetEmployee()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select loginid,birthdate,jobtitle from HumanResources.Employee;";
                cmd.Connection = con;
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();


                    Console.WriteLine(reader.GetName(0) + " " + reader.GetName(1) + " " + reader.GetName(2));
                    Console.WriteLine("=================================");
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " " + reader.GetString(1) + " " + reader[2]);



                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }
    }
}
