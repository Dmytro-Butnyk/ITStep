using lesson_5.Models.Clients;
using lesson_5.Models.Personals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5.Models.Data
{
    public class Purchase
    {
        public int Id { get; set; }
        public Buyer Buyer { get; set; }
        public Product Product { get; set; }
        public Manager Manager { get; set; }

        public override string ToString()
        {
            return $"Purchase {Id}:\n" +
                $"Buyer: {Buyer};\n" +
                $"Product: {Product.Name};\n" +
                $"Manager: {Manager}";
        }
    }
}
