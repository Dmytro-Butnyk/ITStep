using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_10
{
    public delegate bool NumberPredicate(int number);

    public static class Task1
    {
        public static void DisplayNumbers(int[] numbers, NumberPredicate predicate)
        {
            var res = numbers.Where(x => predicate(x));
            Console.WriteLine(string.Join(", ", res));
        }

        public static bool IsEven(int number) => number % 2 == 0;
        public static bool IsOdd(int number) => number % 2 != 0;
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
        public static bool IsFibonacci(int number)
        {
            int a = 0;
            int b = 1;

            while (b < number)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }

            return b == number;
        }

    }
}
