using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_16
{
    public record Laptop(string Model,
        string Manufacturer, double Quantity,
        uint Cores, decimal Price);
}
