using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_13
{
    public abstract class SeaCreature
    {
        private string _type = "Sea Creature";
        public uint Weight { get; set; } = 1;

        public SeaCreature() { }
        public SeaCreature(string type, uint weight)
        {
            _type = type;
            Weight = weight;
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public override string ToString()
        {
            return $"Type: {_type} | Weight: {Weight}";
        }
    }

    public class Fish : SeaCreature
    {
        private string _color = "Grey";

        public Fish():base() { }
        public Fish(string color, string type, uint weight):base(type, weight)
        {
            _color = color;
            Type = type;
            Weight = weight;
        }
    }
    public class Turtle : SeaCreature
    {
        private string _shellColor = "Green";

        public Turtle() : base() { }
        public Turtle(string shellColor, string type, uint weight) : base(type, weight)
        {
            _shellColor = shellColor;
            Type = type;
            Weight = weight;
        }
    }
    public class Shark : SeaCreature
    {
        private string _species = "Great White";

        public Shark() : base() { }
        public Shark(string species, string type, uint weight) : base(type, weight)
        {
            _species = species;
            Type = type;
            Weight = weight;
        }
    }

}
