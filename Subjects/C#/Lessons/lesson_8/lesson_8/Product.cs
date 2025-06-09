using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8
{
    public class Product
    {
        protected string _name, _place;
        protected decimal _price;

        public Product () {
            _name = "NoName";
            _place = "NoPlace";
            _price = 0;
        }
        public Product(string name, string place, decimal price)
        {
            _name = name;
            _place = place;
            _price= price;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if(value == String.Empty) throw new ArgumentNullException("Name can`t be empty!");
                _name = value;
            }
        }
        public string Place
        {
            get { return _place; }
            set
            {
                if (value == String.Empty) throw new ArgumentNullException("Place can`t be empty!");
                _place = value;
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price <= 0 || _price == null) throw new ArgumentException("Wrong price value");
                _price = value;
            }
        }
        public virtual void Input()
        {
            Console.WriteLine("Is product");
        }
        public override string ToString()
        {
            return $"Name: {_name} | Place: {_place} | " +
                $"Price: {_price}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            var other = obj as Product;
            if (other.ToString() == this.ToString())
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
