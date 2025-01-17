using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_4.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student>? Students { get; set; }

        public override string ToString()
        {
            return $"Course:\n" +
                $"Name: {Name}\n" +
                $"Teacher: {Teacher.FirstName + " " + Teacher.LastName}";
        }
    }
}
