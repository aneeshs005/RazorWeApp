using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace BookMyShow.Pages
{
    public class AddIndex : PageModel
    {
        public string Name;
        public string Synopsis;
        public string Year;
        public int count;
        public string[] MovieList { get; set; }
        private readonly ILogger<AddIndex> _logger;

        public AddIndex(ILogger<AddIndex> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public void OnPost(string Name, string Synopsis, string Year)
        {
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\BookMyShowDB;Initial Catalog=BMSDataBase;Integrated Security=True");
            connection.Open();
            int year = Int32.Parse(Year);
            string sqlquery = "INSERT INTO [MovieNames]([Name],[Synopsis],[Year]) VALUES('" + Name + "','" + Synopsis + "', '" + year + "')";
            SqlCommand command = new SqlCommand(sqlquery, connection);
            count = command.ExecuteNonQuery();
        }
    }
}
