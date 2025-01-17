using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lesson_11
{
    public class Backpack
    {
        private string _color;
        private string _manufacturer;
        private int _weight;
        private int _volume;
        private Dictionary<string, int> _items;
        // constructors
        #region
        public Backpack()
        {
            _color = "Black";
            _manufacturer = "Guard";
            _weight = 1;
            _volume = 15;
            _items = new Dictionary<string, int>
            {
                { "Laptop", 8},
                { "Laptop charger", 3},
                { "Mouse", 2}
            };
        }
        public Backpack(string color, string manufacturer, int weight, int volume, Dictionary<string, int> items)
        {
            _color = color;
            _manufacturer = manufacturer;
            _weight = weight;
            _volume = volume;
            Items = items;
        }
        #endregion
        // events
        #region
        public event BackpackEventHandler itemAdded;
        public event BackpackEventHandler itemRemoved;
        public event BackpackOverloadedEventHandler BackpackOverloaded;
        #endregion
        // properties
        #region
        public string Color
        {
            get { return _color; }
        }
        public string Manufacturer
        {
            get { return _manufacturer; }
        }
        public int Weight
        {
            get { return _weight; }
        }
        public int Volume
        {
            get { return _volume; }
        }
        public Dictionary<string, int> Items
        {
            get { return _items; }
            set
            {
                if (value.Sum(item => item.Value) > _volume ||
                    value.Any(item => item.Value <= 0))
                    throw new Exception("Wrong items:" +
                        " sum volume more than backpack or " +
                        "it has values <0.");
                _items = value;
            }
        }
        #endregion
        //methods
        #region
        public void PutItem(string item, int volume)
        {
            if (!_items.ContainsKey(item) &&
                _items.Sum(item => item.Value) + volume <= _volume)
            {
                _items.Add(item, volume);
                itemAdded?.Invoke(item);
            }
            else throw new Exception("Item exists in or volume too high.");
        }
        public void RemoveItem(string item)
        {
            if( _items.ContainsKey(item) )
            {
                _items.Remove(item);
                itemRemoved?.Invoke(item);
            }
        }
        public void CheckWeight(int weightLimit)
        {
            int totalWeight = _items.Sum(item => item.Value);
            if (totalWeight > weightLimit)
            {
                BackpackOverloaded?.Invoke(totalWeight);
            }
        }
        #endregion
        public override string ToString()
        {
            StringBuilder backpack = new();
            backpack.AppendLine($"Color: {_color};");
            backpack.AppendLine($"Manufacturer: {_manufacturer};");
            backpack.AppendLine($"Color: {_weight};");
            backpack.AppendLine($"Volume: {_volume};");
            backpack.AppendLine($"Items:");
            foreach (var item in _items)
            {
                backpack.AppendLine($"{item.Key}: {string.Join(", ", item.Value)}");
            }
            return backpack.ToString();
        }
    }
}
