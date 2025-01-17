using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    public class Bus
    {
        private uint _id = 0;
        private uint _capacity = 10;
        private uint _passengers = 0;

        public Bus() { }
        public Bus(uint id, uint maxPeople)
        {
            _id = id;
            _capacity = maxPeople;
            _passengers = (uint)new Random().Next(1, 5);
        }

        public uint Id 
        { 
            get { return _id; } 
            set { _id =  value; }
        }
        public uint Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        public uint Passengers
        {
            get { return _passengers; }
            set { _passengers = value; }
        }

        public async Task RefreshPassengers()
        {
            Passengers = (uint)new Random().Next(1, 5);
        }

        public async Task<uint> BoardAsync(uint passengers)
        {
            return await Task.Run(() =>
            {
                uint canBoard = Math.Min(passengers, Capacity - Passengers);
                Passengers += canBoard;
                return passengers - canBoard;
            });
        }

        public override string ToString()
        {
            return $"Bus number: {Id} | Capacity: {Capacity} | Passsengers: {Passengers}";
        }
    }
}
