using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WA_les_7_EF3.Data;
using WA_les_7_EF3.Pages.Models;

namespace WA_les_7_EF3.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly WA_les_7_EF3.Data.StudentContext _context;

        public CreateModel(WA_les_7_EF3.Data.StudentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
        ViewData["StudentID"] = new SelectList(_context.Students, "ID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
