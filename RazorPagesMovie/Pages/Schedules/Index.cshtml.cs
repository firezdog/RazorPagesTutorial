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

        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public IndexModel (RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public IList<Schedule> Schedule { get; set; }

        public async Task OnGetAsync ()
        {
            Schedule = await _context.Schedule.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync ()
        {
            //check for initial validation errors
            if (!ModelState.IsValid)
            {
                Schedule = await _context.Schedule.AsNoTracking().ToListAsync();
                return Page();
            }

            //check for file validation errors
            var publicScheduleData =
                await FileHelper.ProcessFormFile(FileUpload.UploadPublicSchedule, ModelState);
            var privateScheduleData =
                await FileHelper.ProcessFormFile(FileUpload.UploadPrivateSchedule, ModelState);

            if (!ModelState.IsValid)
            {
                Schedule = await _context.Schedule.AsNoTracking().ToListAsync();
                return Page();
            }

            //post to database
            var schedule = new Schedule()
            {
                PrivateSchedule = privateScheduleData,
                PrivateScheduleSize = FileUpload.UploadPrivateSchedule.Length,
                PublicSchedule = publicScheduleData,
                PublicScheduleSize = FileUpload.UploadPublicSchedule.Length,
                Title = FileUpload.Title,
                UploadDT = DateTime.UtcNow
            };

            _context.Schedule.Add(schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}