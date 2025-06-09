using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10
{
    public class ArithmeticOperations
    {
        private int _num1;
        public int _num2;

        public ArithmeticOperations()
        {
            _num1 = 0;
            _num2 = 0;
        }
        public ArithmeticOperations(int num1, int num2)
        {
                _num1 = num1;
                _num2 = num2;
        }

        public int Num1
        {
            get {  return _num1; }
            set {  _num1 = value; }
        }
        public int Num2
        {
            get { return _num2; }
            set { _num2 = value; }
        }
        public int Add()
        {
            return _num1 + _num2;
        }
        public int Subs()
        {
            return (_num1 - _num2);
        }
        public int Multiply()
        {
            return _num1 * _num2;
        }
        public int Divide()
        {
            if (_num2 == 0)
            {
                throw new Exception("Second operand can`t be zero");
            }
            return (_num1 / _num2);
        }
        public override string ToString()
        {
            return $"Number 1: {_num1} | Number 2: {_num2}";
        }
    }
}
