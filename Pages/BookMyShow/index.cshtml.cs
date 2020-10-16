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
        private readonly ILogger<BookMyShowModel> _logger;

        public BookMyShowModel(ILogger<BookMyShowModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
