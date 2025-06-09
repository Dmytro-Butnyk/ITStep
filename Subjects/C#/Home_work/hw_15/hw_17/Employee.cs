using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_17
{
    public record Employee(string Name, string Position,
        string PhoneNumber, string EMail, decimal Salary);
}
