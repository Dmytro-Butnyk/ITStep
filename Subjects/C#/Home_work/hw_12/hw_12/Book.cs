using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hw_12
{
    public record Book(string title, string author, string genre, int year)
    {
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;
        public string Genre { get; set; } = genre; 
        public int Year { get; set; } = year;
    }
}
