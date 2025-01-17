using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WA_les_7_EF3.Data;
using WA_les_7_EF3.Pages.Models;

namespace WA_les_7_EF3.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly WA_les_7_EF3.Data.StudentContext _context;

        public IndexModel(WA_les_7_EF3.Data.StudentContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //Eager loading (стрімке завантаження)
            Course = await _context.Courses
                .Include(c => c.Department).ToListAsync();
        }


        //    //Explicit loading(явне завантаження)
        //    Courses = await _context.Courses.ToListAsync();
        //    foreach (var c in Courses)
        //    {
        //        _context.Entry(c).Reference(p => p.Department).Load();

        //    }


        

        //public IList<CourseViewModel> CourseVM { get; set; }
        //public async Task OnGetAsync()
        //{
        //    //Lazy loading - ліниве завантаження
        //    CourseVM = await _context.Courses
        //    .Select(p => new CourseViewModel
        //    {
        //        CourseID = p.CourseID,
        //        Title = p.Title,
        //        Credits = p.Credits,
        //        DepartmentName = p.Department.Name
        //    }).ToListAsync();
        //}


    }
}




