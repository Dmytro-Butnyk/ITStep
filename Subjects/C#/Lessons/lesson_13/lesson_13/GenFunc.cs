using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_13
{
    public static class GenFunc
    {
        public static T MaxOfThree<T>(T a, T b, T c) where T : IComparable<T>
        {
            T max = a; 
            if(b.CompareTo(max) > 0)
            {
                max = b;
            }
            if(c.CompareTo(max) > 0)
            {
                max = c;
            }
            return max;
        }
        public static T MinOfThree<T>(T a, T b, T c) where T : IComparable<T>
        {
            T min = a;
            if (b.CompareTo(min) < 0)
            {
                min = b;
            }
            if (c.CompareTo(min) < 0)
            {
                min = c;
            }
            return min;
        }
        public static T SumArray<T>(params T[] arr)
        {
            T sum = default(T);
            foreach(T it in arr)
            {
                sum = (dynamic)sum + it;
            }
            return sum;
        }
    }
}
