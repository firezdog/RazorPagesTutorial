using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null) {
                Schedule = await _context.Schedule.SingleOrDefaultAsync(s => s.ID == id);
                if (Schedule != null) { return Page(); }
            }
            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            
            if (id != null)
            {
                Schedule = await _context.Schedule.FindAsync(id);

                if (Schedule != null)
                {
                    _context.Schedule.Remove(Schedule);
                    await _context.SaveChangesAsync();
                    return Redirect("./Index");
                }
            }

            return NotFound();
        }
    }
}