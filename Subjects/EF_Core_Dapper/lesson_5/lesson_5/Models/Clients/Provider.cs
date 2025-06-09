using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lesson_5.Models.Data;

namespace lesson_5.Models.Clients
{
    public class Provider : Client
    {
        public List<Supply>? Supplies { get; set; }
    }
}
