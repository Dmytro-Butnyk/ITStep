using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_14
{
    public class Store : IDisposable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public Store(string name, string address, string type)
        {
            Name = name;
            Address = address;
            Type = type;
        }

        public void DisplayStoreInfo()
        {
            Console.WriteLine($"Name: {Name}, Address: {Address}, Type: {Type}");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose method is called.");
        }

        ~Store()
        {
            Console.WriteLine("Destructor is called.");
        }
    }

}
