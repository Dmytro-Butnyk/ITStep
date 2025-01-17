using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5.Models.Products
{
    public class Technique : Product
    {
        public int Warranty { get; set; }
        public string Specialization { get; set; }
    }
}
