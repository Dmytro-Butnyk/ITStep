using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDataBase.Models.BookDetails
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Publisher() { }
        public Publisher(string name)
        {
            Name = name;
        }

        public override string ToString() =>
            $"{Name}";
    }
}
