using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_11
{
    public struct DailyTemperature
    {
        public double HighTemp { get; set; }
        public double LowTemp { get; set; }

        public double Difference => HighTemp - LowTemp;
    }
}
