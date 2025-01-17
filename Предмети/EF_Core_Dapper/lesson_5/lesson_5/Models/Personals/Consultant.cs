using lesson_5.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5.Models.Personals
{
    public class Consultant : Personal
    {
        public List<Call>? Calls { get; set; }
    }
}
