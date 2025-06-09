using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WA_les_7_EF3.Data;
using WA_les_7_EF3.Pages.Models;

namespace WA_les_7_EF3.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly WA_les_7_EF3.Data.StudentContext _context;

        public DeleteModel(WA_les_7_EF3.Data.StudentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);

            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            var cousesCount = await _context.Enrollments.CountAsync(m => m.CourseID == id);
            if (course != null && cousesCount == 0)
            {
                Course = course;
                _context.Courses.Remove(Course);
                await _context.SaveChangesAsync();
            }
            else
            {
                ErrorMessage = "Course is not empty";
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
