using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTickets
{
    internal class MovieTickets
    {
        static String connectionString = @"Data Source=ics-lt-96l96v3\sqlexpress;Initial Catalog=MoviesticketsDB;Integrated Security=True;Pooling=False;";

        public static void DisplayMoviesList()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_displayMovies";
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("{0}\t{1}\t{2}\t\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                    Console.WriteLine(" ");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader[0], reader[1], reader[2], reader[3]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public static void InsertMovies(string MovieTitle, DateTime RelaeaseDate, string Genre)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_insertMovies";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@mtitle";
                    parameter1.SqlDbType = SqlDbType.VarChar;
                    parameter1.Value = MovieTitle;
                    cmd.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@releasedate";
                    parameter2.SqlDbType = SqlDbType.DateTime;
                    parameter2.Value = RelaeaseDate;
                    cmd.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@genre";
                    parameter3.SqlDbType = SqlDbType.VarChar;
                    parameter3.Value = Genre;
                    cmd.Parameters.Add(parameter3);

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = cmd;
                    int i = adapter.InsertCommand.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Console.WriteLine("New Category Inserted Successfully...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateMovies(string connectionString, int MovieID, string MovieTitle, DateTime RelaeaseDate, string Genre)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_UpdateMovies";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@mid";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = MovieID;
                    command.Parameters.Add(parameter);

                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@mtitle";
                    parameter1.SqlDbType = SqlDbType.VarChar;
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = MovieTitle;
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@releasedate";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = RelaeaseDate;
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@genre";
                    parameter3.SqlDbType = SqlDbType.VarChar;
                    parameter3.Direction = ParameterDirection.Input;
                    parameter3.Value = Genre;
                    command.Parameters.Add(parameter3);
                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adapter.UpdateCommand = command;
                    int i = adapter.UpdateCommand.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("Data has been Updated succesfully...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public static void deleteMovies(int MovieID)

        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_deleteMovies";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@mid";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = MovieID;
                    command.Parameters.Add(parameter);
                    con.Open();
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("Data deleted successfully...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public static void DisplayTicketSales()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_displayTickets";
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4), reader.GetName(5));
                    Console.WriteLine(" ");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t\t\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }


        public static double Calculateamount(int QuantityOfTickets, float Price)
        {
            return QuantityOfTickets * Price;
        }


        public static void InsertTickets(int SalesID, int MovieId, int ScreenNo, string ShowTime, int QuantityOfTickets, float Price)
        {
            double Totalmount = Calculateamount(QuantityOfTickets, Price);
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_insertTickets";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter7 = new SqlParameter();
                    parameter7.ParameterName = "@sid";
                    parameter7.SqlDbType = SqlDbType.Int;
                    parameter7.Value = SalesID;
                    cmd.Parameters.Add(parameter7);

                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@mid";
                    parameter1.SqlDbType = SqlDbType.Int;
                    parameter1.Value = MovieId;
                    cmd.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@screenno";
                    parameter2.SqlDbType = SqlDbType.Int;
                    parameter2.Value = ScreenNo;
                    cmd.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@showtime";
                    parameter3.SqlDbType = SqlDbType.VarChar;
                    parameter3.Value = ShowTime;
                    cmd.Parameters.Add(parameter3);

                    SqlParameter parameter4 = new SqlParameter();
                    parameter4.ParameterName = "@Qty";
                    parameter4.SqlDbType = SqlDbType.Int;
                    parameter4.Value = QuantityOfTickets;
                    cmd.Parameters.Add(parameter4);

                    SqlParameter parameter5 = new SqlParameter();
                    parameter5.ParameterName = "@amt";
                    parameter5.SqlDbType = SqlDbType.Float;
                    parameter5.Value = Totalmount;
                    cmd.Parameters.Add(parameter5);

                    SqlParameter parameter6 = new SqlParameter();
                    parameter6.ParameterName = "@price";
                    parameter6.SqlDbType = SqlDbType.Float;
                    parameter6.Value = Price;
                    cmd.Parameters.Add(parameter6);

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = cmd;
                    int i = adapter.InsertCommand.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Console.WriteLine("New Category Inserted Successfully...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public static void UpdateTickets(string connectionString, int SalesID, int MovieId, int ScreenNo, string ShowTime, int QuantityOfTickets, float Price)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_UpdateTickets";

                    SqlParameter parameter5 = new SqlParameter();
                    parameter5.ParameterName = "@sid";
                    parameter5.SqlDbType = SqlDbType.Int;
                    parameter5.Value = SalesID;
                    command.Parameters.Add(parameter5);

                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@mid";
                    parameter1.SqlDbType = SqlDbType.Int;
                    parameter1.Value = MovieId;
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@screenno";
                    parameter2.SqlDbType = SqlDbType.Int;
                    parameter2.Value = ScreenNo;
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@showtime";
                    parameter3.SqlDbType = SqlDbType.VarChar;
                    parameter3.Value = ShowTime;
                    command.Parameters.Add(parameter3);

                    SqlParameter parameter4 = new SqlParameter();
                    parameter4.ParameterName = "@Qty";
                    parameter4.SqlDbType = SqlDbType.Int;
                    parameter4.Value = QuantityOfTickets;
                    command.Parameters.Add(parameter4);

                    /*   SqlParameter parameter5 = new SqlParameter();
                       parameter5.ParameterName = "@amt";
                       parameter5.SqlDbType = SqlDbType.Float;
                       parameter5.Value = Amount;
                       command.Parameters.Add(parameter5); */

                    SqlParameter parameter6 = new SqlParameter();
                    parameter6.ParameterName = "@price";
                    parameter6.SqlDbType = SqlDbType.Float;
                    parameter6.Value = Price;
                    command.Parameters.Add(parameter6);
                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adapter.UpdateCommand = command;
                    int i = adapter.UpdateCommand.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("Data has been Updated succesfully...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public static void DeleteTickets(int SalesID)

        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_deleteTicketSales";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@sid";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = SalesID;
                    command.Parameters.Add(parameter);
                    con.Open();
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("Data deleted successfully...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void TopMovie()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_getTopMovie";
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));
                    Console.WriteLine(" ");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader[0], reader[1].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
    