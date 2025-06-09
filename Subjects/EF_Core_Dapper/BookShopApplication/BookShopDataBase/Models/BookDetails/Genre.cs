using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDataBase.Models.BookDetails
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre() { }
        public Genre(string name)
        {
            Name = name;
        }

        public override string ToString() =>
            $"{Name}";
    }
}
