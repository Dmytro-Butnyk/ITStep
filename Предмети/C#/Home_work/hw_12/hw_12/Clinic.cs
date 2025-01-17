using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_12
{
    public class Patient
    {
        public string Name { get; set; }
        public int Priority { get; set; }
    }

    public class ClinicQueue
    {
        PriorityQueue<Patient, int> queue = new PriorityQueue<Patient, int>();

        public void Arrive(Patient patient)
        {
            queue.Enqueue(patient, patient.Priority);
        }

        public Patient NextPatient()
        {
            if (queue.TryDequeue(out Patient nextPatient, out _))
            {
                return nextPatient;
            }
            else
            {
                return null;
            }
        }

    }

}
