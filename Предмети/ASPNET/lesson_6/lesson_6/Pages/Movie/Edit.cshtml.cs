using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lesson_6.Data;
using lesson_6.Models;

namespace lesson_6.Pages.Movie
{
    public class EditModel : PageModel
    {
        private readonly lesson_6.Data.MovieDbContext _context;

        public EditModel(lesson_6.Data.MovieDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie =  await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            Movie = movie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(uint id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
