 using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_4
{
    public class Town
    {
        private string _townName { get; set; }
        private string _countryName { get; set; }
        private int _numPeople { get; set; }
        private int _phoneCode { get; set; }
        private string[] _townDistricts { get; set; }
        public Town()
        {
            _townName = "No town name";
            _countryName = "No country name";
            _numPeople = 0;
            _phoneCode = 0;
            _townDistricts = ["No districts"];
        }
        public Town(string tName, string cName, int numPeople,
            int phoneCode, string[] districts)
        {
            _townName = tName;
            _countryName = cName;
            _numPeople = numPeople;
            _phoneCode = phoneCode;
            _townDistricts = districts;
        }

        public void Input()
        {
            int num;
            Console.WriteLine("New town:\n" +
                "Town name: ");
            _townName = Console.ReadLine();
            Console.WriteLine("Country name:");
            _countryName = Console.ReadLine();
            Console.WriteLine("Number of inhabitants:");
            Check(out num);
            _numPeople = num;
            Console.WriteLine("Phone code:");
            Check(out num);
            _phoneCode = num;
            Console.WriteLine("Enter number of districts:");
            Check(out num);
            _townDistricts = new string[num];
            for(int i = 0; i < num; i++)
            {
                Console.WriteLine($"District number {i+1}");
                _townDistricts[i] = Console.ReadLine();
            }
        }
        public void Show()
        {
            Console.WriteLine($"Town name: {_townName}, country name: {_countryName}\n" +
                $"number of inhabitants: {_numPeople}, phone code: {_phoneCode}");
            Console.WriteLine("Districts:");
            for(int i = 0; i < _townDistricts.Length; ++i)
            {
                Console.WriteLine($"{i + 1}. {_townDistricts}");
            }
        }
        static private void Check<T>(out T num) where T : struct
        {
            num = default(T);
            try
            {
                string input = Console.ReadLine();
                num = (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                Console.WriteLine("Wrong value!");
            }
        }
    }
}
