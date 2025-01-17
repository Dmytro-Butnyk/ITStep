using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lesson_8
{
    public class Toy : Product
    {
        private string _ageCategory;
        private string _placeOfProduction;
        public Toy() : base()
        {
            _ageCategory = "0";
            _placeOfProduction = "Unknown";
        }
        public Toy(string name, string place, decimal price,
            string ageCategory, string placeOfProduction) :
            base(name, place, price)
        {
            _ageCategory = ageCategory;
            _placeOfProduction = placeOfProduction;
        }
        public string AgeCategory
        {
            get { return _ageCategory; }
            set
            {
                string pattern = "^(?:[1-9]|[1-9][0-9]|100)-(?:[1-9]|[1-9][0-9]|100)$";
                Regex regex = new(pattern);
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Wrong age diapason!");
                _ageCategory = value;
            }
        }
        public string PlaceOfProduction
        {
            get { return _placeOfProduction; }
            set
            {
                if (value == String.Empty)
                    throw new ArgumentNullException("Place of production can`t be empty");
            }
        }
        public override void Input()
        {
            Console.WriteLine("is toy");
        } 
        public override string ToString()
        {
            return base.ToString() + $" | Age category: {_ageCategory} |" +
                $" Place of production: {_placeOfProduction}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            var other = obj as Toy;
            if(other.ToString() == this.ToString())
            return true;
            return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
