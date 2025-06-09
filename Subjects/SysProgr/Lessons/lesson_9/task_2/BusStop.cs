using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    public class BusStop
    {

        private Dictionary<uint, uint> passengers = new Dictionary<uint, uint>();

        public BusStop()
        {
            Random rand = new Random();
            for(uint i = 1; i < 5; i++)
            {
                passengers.Add(i, (uint)rand.Next(1, 30));
            }
        }

        public async Task ArriveAsync(Bus bus)
        {
            if (passengers.ContainsKey(bus.Id))
            {
                passengers[bus.Id] = await bus.BoardAsync(passengers[bus.Id]);
            }
        }
        public Task AddPassengersAsync(uint busNumber, uint count)
        {
            return Task.Run(() =>
            {
                if (!passengers.ContainsKey(busNumber))
                {
                    passengers[busNumber] = 0;
                }
                passengers[busNumber] += count;
            });
        }

        public override string ToString()
        {
            string result = "BusStop:\n";
            foreach (var pair in passengers)
            {
                result += $"Wished number: {pair.Key}, number of passengers: {pair.Value}\n";
            }
            return result;
        }
    }
}
