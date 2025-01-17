using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hw_5
{
    public class OperatorCalc
    {
        private string  _expr;
        public OperatorCalc(string expr) 
        {
            CheckValid(expr);
            _expr = expr;
        }
        public string Expr
        {
            get { return _expr; }
            set {
                CheckValid(value);
                _expr = value;
            }
        }
        public bool OperationResult()
        {
            int[] s = _expr.Split("><!=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            if(_expr.Contains(">") && !_expr.Contains("=")) return s[0] > s[1];
            else if(_expr.Contains("<") && !_expr.Contains("=")) return s[0] < s[1];
            else if (_expr.Contains(">=")) return s[0] >= s[1];
            else if (_expr.Contains("<=")) return s[0] <= s[1];
            else if (_expr.Contains("==")) return s[0] == s[1];
            else if (_expr.Contains("!=")) return s[0] != s[1];
            else throw new Exception("Wrong values in expression");
        }

        private void CheckValid(string s)
        {
            if (s.Any(char.IsLetter)) throw new Exception("Wrong values");
            if (s.Split("><!=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray().Length != 2) throw new Exception("Wrong format");
        }
        public override string ToString()
        {
            return _expr;
        }
    }
}
