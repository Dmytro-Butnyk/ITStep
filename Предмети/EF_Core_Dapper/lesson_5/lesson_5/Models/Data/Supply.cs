using lesson_5.Models.Clients;
using lesson_5.Models.Personals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5.Models.Data
{
    public class Supply
    {
        public int Id { get; set; }
        public Provider Provider { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Manager Manager { get; set; }

        public override string ToString()
        {
            return $"Supply {Id}:\n" +
                $"Provider: {Provider};\n" +
                $"Product: {Product.Name};\n" +
                $"Quantity: {Quantity};\n" +
                $"Manager: {Manager}";
        }
    }
}
