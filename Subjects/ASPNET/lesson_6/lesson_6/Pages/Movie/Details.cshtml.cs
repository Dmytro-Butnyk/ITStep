using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lesson_6.Data;
using lesson_6.Models;

namespace lesson_6.Pages.Movie
{
    public class DetailsModel : PageModel
    {
        private readonly lesson_6.Data.MovieDbContext _context;

        public DetailsModel(lesson_6.Data.MovieDbContext context)
        {
            _context = context;
        }

        public Models.Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
