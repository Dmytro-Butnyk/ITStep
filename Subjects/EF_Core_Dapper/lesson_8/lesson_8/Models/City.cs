using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country? Country {  get; set; }

        public City() { }
        public City(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }

        public override string ToString() =>
            $"City name: {Name}";
    }
}
