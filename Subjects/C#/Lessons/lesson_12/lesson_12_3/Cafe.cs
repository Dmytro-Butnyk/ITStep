using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_12_3
{
    public class Cafe
    {
        private Queue<string> queue = new Queue<string>();
        private List<string> tables = new List<string>();

        public void Arrive(string customer, bool hasReservation = false)
        {
            if (hasReservation || tables.Count < 5)
            {
                tables.Add(customer);
                Console.WriteLine($"{customer} sit by table.");
            }
            else
            {
                queue.Enqueue(customer);
                Console.WriteLine($"{customer} stay in queue.");
            }
        }

        public void Leave()
        {
            if (tables.Count > 0)
            {
                string customer = tables[0];
                tables.RemoveAt(0);
                Console.WriteLine($"{customer} leave cafe.");

                if (queue.Count > 0)
                {
                    string nextCustomer = queue.Dequeue();
                    tables.Add(nextCustomer);
                    Console.WriteLine($"{nextCustomer} take free table.");
                }
            }
        }
    }
}
