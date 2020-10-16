using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookMyShow.Pages
{
    //On first page load the app goes to the OnGet Method and then to Get Form and prints already active text file
    //After clicking submit the app goes to onPost method updates the string,
    //goes to Get Form and prints the string again with the new added task
    public class ToDoIndexModel : PageModel
    {
        private readonly ILogger<ToDoIndexModel> _logger;
        public string[] Todolist{get; set;}
        public ToDoIndexModel(ILogger<ToDoIndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Todolist = System.IO.File.ReadAllLines("Pages/ToDoList/List.txt");
        }
        public void OnPost()
        {
            string task = Request.Form["newtask"];
            System.IO.File.AppendAllText("Pages/ToDoList/List.txt", task + Environment.NewLine);
            Todolist = System.IO.File.ReadAllLines("Pages/ToDoList/List.txt");
        }
    }
}
