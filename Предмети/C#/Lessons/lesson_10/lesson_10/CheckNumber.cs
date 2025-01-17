using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10
{
    public static class CheckNumber
    {
        public static bool IsPair(int n)
        {
            return n % 2 == 0;
        }
        public static bool IsUnpair(int n)
        {
            return n % 2 != 0;
        }
        public static bool IsSimple(int n)
        {
            int count = 0;
            for(int i = 1; i <= n; ++i)
            {
                if(n % i == 0)
                {
                    count++;
                }
            }
            if(count == 2)
                return true;
                return false;
        }
        public static bool IsFibonacci(int number)
        {
            return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
        }
        private static bool IsPerfectSquare(int number)
        {
            int sqrt = (int)Math.Sqrt(number);
            return sqrt * sqrt == number;
        }
    }
}
