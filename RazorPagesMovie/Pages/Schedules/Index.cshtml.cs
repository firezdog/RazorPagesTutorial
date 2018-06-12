using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using RazorPagesMovie.Utilities;

namespace RazorPagesMovie.Pages.Schedules
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public FileUpload FileUpload { get; set; }
        [BindProperty]
        public IList<Schedule> Schedule { get; set; }


        public void OnGet()
        {

        }
    }
}