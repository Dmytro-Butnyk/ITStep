using BookShopDataBase.Models.BookDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDataBase.Models.DiscountTable
{
    public class DiscountGenre
    {
        public int Id {  get; set; }
        public Genre Genre { get; set; }
        public double Percent { get; set; }

        public DiscountGenre() { }
        public DiscountGenre(Genre genre)
        {
            Genre = genre;
        }

        public override string ToString() =>
            $"{Genre}| {Percent}%";
    }
}
