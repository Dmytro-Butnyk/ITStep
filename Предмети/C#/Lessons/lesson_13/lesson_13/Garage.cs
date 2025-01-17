using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lesson_13
{
    public class Garage : IEnumerable<Vehicle>
    {
        private int _capacity;
        private List<Vehicle> _vehicles;

        public Garage()
        {
            _capacity = 1;
            _vehicles = new List<Vehicle>{ new Vehicle() };
        }
        public Garage(List<Vehicle> vehicles)
        {
            if (vehicles == null) throw new Exception("List of cars is null");
            _vehicles = vehicles;
            _capacity = _vehicles.Count;
        }
        public int Capacity
        {
            get { return _capacity; }
            set { 
                if(value < _capacity)
                {
                    foreach(var it in _vehicles)
                    {
                        if(_vehicles.Count > value)
                        {
                            _vehicles.Remove(it);
                        }
                    }
                }
                _capacity = value; 
            }
        }
        public void AddCar(Vehicle vehicle)
        {
            if(_capacity == _vehicles.Count)
            {
                WriteLine("Garage is full. Vehicle is not added");
            }
            _vehicles.Add(vehicle);
        }
        public void RemoveCar(string name)
        {
            foreach (Vehicle vehicle in _vehicles)
            {
                if (name == vehicle.Name)
                {
                    _vehicles.Remove(vehicle);
                    break;
                }
            }
        }
        public IEnumerator<Vehicle> GetEnumerator()
        {
            return _vehicles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override string ToString()
        {
            return $"Garage capacity: {_capacity}";
        }
    }
}
