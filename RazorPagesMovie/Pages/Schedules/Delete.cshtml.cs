using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Schedules
{
    public class DeleteModel : PageModel
    {

        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        [BindProperty]
        public Schedule Schedule { get; set; }

        public DeleteModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id != null) {
                Schedule = _context.Schedule.Where(s => s.ID == id).SingleOrDefault();
                return Page();
            }

            return NotFound();

        }
    }
}