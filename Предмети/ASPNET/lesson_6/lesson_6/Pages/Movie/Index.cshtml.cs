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
    public class IndexModel : PageModel
    {
        private readonly lesson_6.Data.MovieDbContext _context;

        public IndexModel(lesson_6.Data.MovieDbContext context)
        {
            _context = context;
        }

        public IList<Models.Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
