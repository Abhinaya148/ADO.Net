using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    internal class Gradebook
    {
        public static void insertstudent(int stu_id, string stu_name)
        {
            try
            {
                string connectionstring = "data source=ICS-LT-56L96V3\\SQLEXPRESS;database=Studentgradedb; integrated security=true;";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_insertstudent";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@stu_id";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = stu_id;
                    cmd.Parameters.Add(param1);

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@stu_name";
                    param2.SqlDbType = SqlDbType.VarChar;
                    param2.Value = stu_name;
                    cmd.Parameters.Add(param2);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.InsertCommand = cmd;
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Console.WriteLine(stu_id+" "+stu_name+ " data inserted successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
