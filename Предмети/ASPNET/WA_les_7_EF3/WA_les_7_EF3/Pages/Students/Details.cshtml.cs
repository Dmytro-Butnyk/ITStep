using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WA_les_7_EF3.Data;
using WA_les_7_EF3.Pages.Models;

namespace WA_les_7_EF3.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly WA_les_7_EF3.Data.StudentContext _context;

        public DetailsModel(WA_les_7_EF3.Data.StudentContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;
        public List<Course> Courses { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            
            var enrollments = await _context.Enrollments
                .Where(m => m.StudentID == id)
                .ToListAsync();

            var coursesIds = enrollments.Select(e => e.CourseID).ToList();

            var courses = await _context.Courses
                .Where(x => coursesIds.Contains(x.CourseID))
                .ToListAsync();

            Courses = courses;
            
            return Page();
        }
    }
}
