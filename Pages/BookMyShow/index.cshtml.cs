using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookMyShow.Pages
{
    public class BookMyShowModel : PageModel
    {
        public string Name;
        public string Synopsis;
        public string Year;
        public int count;
        public Dictionary<int, Movies> dictMovies = new Dictionary<int, Movies>();
        private readonly ILogger<BookMyShowModel> _logger;

        public BookMyShowModel(ILogger<BookMyShowModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost(string Name, string Synopsis, string Year)
        {
            dictMovies.Add(count, new Movies(Name,Synopsis, Int32.Parse(Year)));
            count++;
        }
    }
    public class Movies
        {
            public Movies() { }  //Default Constructor
            public Movies(string movieName, string synopsis, int year)
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
            //public MovieBooking Bookings { get; set; }
        }
}
