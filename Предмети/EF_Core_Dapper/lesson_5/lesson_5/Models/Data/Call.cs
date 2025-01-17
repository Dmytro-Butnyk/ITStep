using lesson_5.Models.Personals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5.Models.Data
{
    public class Call
    {
        public int Id { get; set; }
        public Consultant Consultant { get; set; }
        public Client Client { get; set; }
        public DateTime CallTime { get; set; }

        public override string ToString()
        {
            return $"Call {Id}:\n" +
                $"Consultant: {Consultant};\n" +
                $"Client: {Client};\n" +
                $"Call time: {CallTime}";
        }
    }
}
