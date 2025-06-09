using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public List<Country>? Countries { get; set;}

        public Continent() { }
        public Continent(string name)
        {
            Name = name;
        }

        public override string ToString() =>
            $"Continent name: {Name}";
    }
}
