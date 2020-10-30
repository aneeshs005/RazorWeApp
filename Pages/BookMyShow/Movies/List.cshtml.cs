using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BookMyShow.Pages.BookMyShow.Movies
{
    public class ListModel : PageModel
    {
        public List<AllMovies> MovieList = new List<AllMovies>();
        public void OnGet()
        {
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\BookMyShowDB;Initial Catalog=BMSDataBase;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM MovieNames", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MovieList.Add(new AllMovies(reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
            }
        }
    }
    public class AllMovies
    {
        public AllMovies() { }  //Default Constructor
        public AllMovies(string movieName, string synopsis, int year)
        {
            this.MovieName = movieName;
            this.Synopsis = synopsis;
            this.Year = year;
        }
        public string MovieName { get; private set; } //private set to not allow the values to be changed from outside
        public string Synopsis { get; private set; }
        public int Year { get; private set; }
        public override string ToString()  // Overriding to get the value instead of types
        {
            return " Movie Name:" + this.MovieName + "\n Description:" + this.Synopsis + "\n Release Year:" + this.Year;
        }
    }
}
