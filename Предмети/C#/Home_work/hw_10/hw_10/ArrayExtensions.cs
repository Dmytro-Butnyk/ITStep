using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_10
{
    public static class ArrayExtensions
    {
        private static Predicate<int> isEven = n => n % 2 == 0;
        public static int[] Filter(this int[] numbers)
        {
            return numbers.Where(n => isEven(n)).ToArray();
        }
    }
}
