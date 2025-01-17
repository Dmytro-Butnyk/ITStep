using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_4.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Adress? Adress { get; set; }
        public virtual ICollection<Teacher>? Teachers { get; set; }

    }
}
