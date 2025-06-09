using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_4.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }

        public override string ToString()
        {
            string st = $"Student:\n" +
                $"First name: {FirstName}\n" +
                $"Last name: {LastName}\n";
            if(Courses != null)
            {
                Courses
                    .ToList().ForEach(x => st += x.ToString() + "\n");
            }

            return st;
        }
    }
}
