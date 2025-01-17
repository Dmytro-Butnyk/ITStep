using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class FractionClass
    {
        private int numerator;
        private int denominator;

        public FractionClass(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public void Add(FractionClass other)
        {
            int commonDenominator = denominator * other.denominator;
            int newNumerator = numerator * other.denominator + other.numerator * denominator;

            numerator = newNumerator;
            denominator = commonDenominator;
        }

        public void Subtract(FractionClass other)
        {
            int commonDenominator = denominator * other.denominator;
            int newNumerator = numerator * other.denominator - other.numerator * denominator;

            numerator = newNumerator;
            denominator = commonDenominator;
        }

        public void Multiply(FractionClass other)
        {
            numerator *= other.numerator;
            denominator *= other.denominator;
        }

        public void Divide(FractionClass other)
        {
            int temp = numerator;
            numerator = denominator * other.numerator;
            denominator = temp * other.denominator;
        }
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false ;
            var other = obj as FractionClass;
            return ToString() == other.ToString();
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }

}
