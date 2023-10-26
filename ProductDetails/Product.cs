using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace CodingA
{
    internal class Product
    {
        public static void InsertCategory(int prodid, string prodname, int price, int qty)
        {
            try
            {
                string cs = "Data Source=ICS-LT-56L96V3\\SQLEXPRESS;" + "Initial Catalog=AbhiDb; Integrated Security=True;";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_insertprod";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@prodid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = prodid;



                    cmd.Parameters.Add(param1);



                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@prodname";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = prodname;



                    cmd.Parameters.Add(param2);



                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@price";
                    param3.SqlDbType = SqlDbType.Money;
                    param3.Value = price;



                    cmd.Parameters.Add(param3);



                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@qty";
                    param4.SqlDbType = SqlDbType.Int;
                    param4.Value = qty;



                    cmd.Parameters.Add(param4);



                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine(prodid + " " + prodname + " " + price + " " + qty + "\ndata inserted succesfully");
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void Getprodinfo()
        { 

            {
                string query = "select * from prod;";
                string cs = "Data Source=ICS-LT-56L96V3\\SQLEXPRESS;" + "Initial Catalog=AbhiDb; Integrated Security=True;";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    //working with stored procedures



                    // creating command & setting its properties



                    SqlCommand command = new SqlCommand();



                    command.Connection = con;



                    command.CommandText = "selectproduct";



                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    // SqlDataAdapter to execute the query and retrieve data.
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataSet dataSet = new DataSet();

                    // Fill the DataSet with data from the 'Prod' table.
                    da.Fill(dataSet, "Prod");

                    foreach (DataRow dr in dataSet.Tables["Prod"].Rows)
                    {
                        Console.WriteLine("{0} \t{1}\t{2}", dr[0], dr[1], dr[2]);

                    }
                }

            }
        }

        public static void UpdatePrice(int prodid, string prodname, int newprice, int qty)
        {
            try
            {
                string cs = "Data Source=ICS-LT-56L96V3\\SQLEXPRESS;" + "Initial Catalog=AbhiDb; Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_updateprice";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@prodid";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = prodid;
                    command.Parameters.Add(parameter);

                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@prodname";
                    parameter1.SqlDbType = SqlDbType.NVarChar;
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = prodname;
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@newprice";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = newprice;
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@qty";
                    parameter3.SqlDbType = SqlDbType.Float;
                    parameter3.Direction = ParameterDirection.Input;
                    parameter3.Value = qty;
                    command.Parameters.Add(parameter3);
                    conn.Open();

                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        // Data updated successfully
                        Console.WriteLine("updated successfully");

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}


