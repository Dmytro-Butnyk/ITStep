using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_11
{
    public delegate void BackpackEventHandler(string item);
    public delegate void BackpackOverloadedEventHandler(int totalWeight);
}
