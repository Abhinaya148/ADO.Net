using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTickets
{
    internal class Program
    {
        static String connectionString =@"Data Source=ICS-LT-56L96V3\SQLEXPRESS;Initial Catalog=MovieDb;Integrated Security=True";
        static void Main(string[] args)
        {
            Console.WriteLine("***MOVIE BOOK****\n");
            while (true)
            {
                Console.WriteLine("1. Insert the Movies info");
                Console.WriteLine("2. Display the Movies info");
                Console.WriteLine("3. Update the Movies info");
                Console.WriteLine("4. Delete the Movies info");
                Console.WriteLine(" ");
                Console.WriteLine("5. Insert the TicketSales Data");
                Console.WriteLine("6. Display the TicketSales Data");
                Console.WriteLine("7. Update the TicketSales Data");
                Console.WriteLine("8. Delete the TicketSales Data");
                Console.WriteLine(" ");
                Console.WriteLine("9. Get Top Rated Movie from the list\n");
                Console.WriteLine("Enter your Choice");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Insert the MovieTitle, ReleaseDate and Genre in Movies Table");
                        string moviename = Console.ReadLine();
                        DateTime relesedate = Convert.ToDateTime(Console.ReadLine());
                        string genres = Console.ReadLine();
                        MovieTickets.InsertMovies(moviename, relesedate, genres);
                        break;
                    case "2":
                        MovieTickets.DisplayMoviesList();
                        break;
                    case "3":
                        Console.WriteLine("Update the Movietitle, releasedate and genre of selected MovieID");
                        int movid = Convert.ToInt32(Console.ReadLine());
                        string moviesname = Console.ReadLine();
                        DateTime newdate = Convert.ToDateTime(Console.ReadLine());
                        string newgenre = Console.ReadLine();
                        MovieTickets.UpdateMovies(connectionString, movid, moviesname, newdate, newgenre);
                        break;
                    case "4":
                        Console.WriteLine("Delete the selected MovieID from the list:");
                        int moviesid = Convert.ToInt32(Console.ReadLine());
                        MovieTickets.deleteMovies(moviesid);
                        break;
                    case "5":
                        Console.WriteLine("Insert the mid, screenno, showtime, quantity, amount and pice of tickets");
                        int ssid = Convert.ToInt32(Console.ReadLine());
                        int mmid = Convert.ToInt32(Console.ReadLine());
                        int sscreen = Convert.ToInt32(Console.ReadLine());
                        string showtimings = Console.ReadLine();
                        int qtyy = Convert.ToInt32(Console.ReadLine());
                        // float ammount = Convert.ToSingle(Console.ReadLine());
                        float pricce = Convert.ToSingle(Console.ReadLine());
                        MovieTickets.InsertTickets(ssid, mmid, sscreen, showtimings, qtyy, pricce);
                        break;
                    case "6":
                        MovieTickets.DisplayTicketSales();
                        break;
                    case "7":
                        Console.WriteLine("Update all the fields with the selected movieid");
                        int siid = Convert.ToInt32(Console.ReadLine());
                        int miid = Convert.ToInt32(Console.ReadLine());
                        int sno = Convert.ToInt32(Console.ReadLine());
                        string show = Console.ReadLine();
                        int qtty = Convert.ToInt32(Console.ReadLine());
                        // float amtt = Convert.ToSingle(Console.ReadLine());
                        float pprice = Convert.ToSingle(Console.ReadLine());
                        MovieTickets.UpdateTickets(connectionString, siid, miid, sno, show, qtty, pprice);
                        break;
                    case "8":
                        Console.WriteLine("Delete the selected SalesID");
                        int sidd = Convert.ToInt32(Console.ReadLine());
                        MovieTickets.DeleteTickets(sidd);
                        break;
                    case "9":
                        Console.WriteLine("Most Viewed Top Rating Movie is:\n ");
                        MovieTickets.TopMovie();
                        break;
                    case "10":
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Invalid Option! Please try again Later...");
                        break;
                }
            }
        }
        
    }
}
