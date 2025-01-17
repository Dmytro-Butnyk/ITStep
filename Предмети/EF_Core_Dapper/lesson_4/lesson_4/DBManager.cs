using lesson_3;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_4
{
    public class DBManager
    {
        private SampleContext _context = new();
        public DBManager() { }

        // LAB

        public void ShowStudents()
        {
            var students = _context.Students;
            students.ToList().ForEach(Console.WriteLine);    
        }

    }
}
