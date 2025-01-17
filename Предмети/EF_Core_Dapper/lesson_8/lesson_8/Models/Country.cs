using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }
        public Continent Continent {  get; set; }
        public List<City>? Cities { get; set; }

        public Country() { }
        public Country(string name, int continentId)
        {
            Name = name;
            ContinentId = continentId;
        }

        public override string ToString() =>
            $"Country name: {Name}";
    }
}
