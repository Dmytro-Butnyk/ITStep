using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lesson_13
{
    public class Vehicle
    {
        private string _color;
        private string _name;
        private int _maxSpeed;

        public Vehicle()
        {
            _color = "NoColor";
            _name = "NoName";
            _maxSpeed = 0;
        }
        public Vehicle(string color, string name, int maxSpeed)
        {
            _color = color;
            _name = name;
            _maxSpeed = maxSpeed;
        }

        public string Color
        {
            get { return _color; }
            set 
            {
                if (Enum.IsDefined(typeof(ConsoleColor), value)) _color = value;
                else
                {
                    WriteLine("Wrong color, try again");
                }
            }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MaxSpeed
        {
            get { return _maxSpeed; }
            set { _maxSpeed = value; }
        }
        public override string ToString()
        {
            return $"Name: {_name} | Color: {_color} | Max speed: {_maxSpeed}";
        }
    }
}
