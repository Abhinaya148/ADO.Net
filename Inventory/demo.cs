using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory1
{
    internal class demo
    {
        static String connectionstring = "Data Source=ICS-LT-56L96V3\\SQLEXPRESS;" + "Initial Catalog=InventoryDb; Integrated Security=True;";

        public static void insertprod(int Productid, string ProductName, int QuantityStock, int Price)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_insertprod";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@Productid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = Productid;



                    cmd.Parameters.Add(param1);



                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@ProductName";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = ProductName;



                    cmd.Parameters.Add(param2);



                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@QuantityStock";
                    param3.SqlDbType = SqlDbType.Money;
                    param3.Value = QuantityStock;



                    cmd.Parameters.Add(param3);



                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@Price";
                    param4.SqlDbType = SqlDbType.Int;
                    param4.Value = Price;



                    cmd.Parameters.Add(param4);



                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine(ProductName + " data inserted succesfully");
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



            try



            {



                using (SqlConnection con = new SqlConnection(connectionstring))



                {



                    //working with stored procedures



                    // creating command & setting its properties



                    SqlCommand command = new SqlCommand();



                    command.Connection = con;



                    command.CommandText = "selectproduct";



                    command.CommandType = CommandType.StoredProcedure;





                    con.Open();



                    using (SqlDataReader reader = command.ExecuteReader())



                    {



                        if (reader.HasRows)



                        {



                            while (reader.Read())



                            {



                                Console.WriteLine("{0} {1} {2} {3} ",



                                    reader[0], reader[1], reader[2], reader[3]);



                            }



                        }



                        else



                        {



                            Console.WriteLine("No records found");



                        }



                        reader.Close();



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

