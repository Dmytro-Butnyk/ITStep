﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WA_les_7_EF3.Data;
using WA_les_7_EF3.Pages.Models;

namespace WA_les_7_EF3.Pages.Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly WA_les_7_EF3.Data.StudentContext _context;

        public DetailsModel(WA_les_7_EF3.Data.StudentContext context)
        {
            _context = context;
        }

        public Instructor Instructor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors.FirstOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }
            else
            {
                Instructor = instructor;
            }
            return Page();
        }
    }
}
