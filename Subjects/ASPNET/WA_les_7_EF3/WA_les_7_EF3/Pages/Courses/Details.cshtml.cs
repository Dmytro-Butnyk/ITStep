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
    public class DetailsModel : PageModel
    {
        private readonly WA_les_7_EF3.Data.StudentContext _context;

        public DetailsModel(WA_les_7_EF3.Data.StudentContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = default!;
        public List<Student> Students { get; set; } = default!;

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

            var enrollments = await _context.Enrollments
                .Where(m => m.CourseID == id)
                .ToListAsync();
            
            var students = _context.Students
                .Where(x => enrollments
                    .Select(e => e.StudentID)
                    .Contains(x.ID))
                .ToList();

            Students = students;

            return Page();
        }
    }
}
