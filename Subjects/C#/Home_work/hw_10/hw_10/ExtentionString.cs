using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_10
{
    public static class ExtentionString
    {
        public static bool IsValidBrackets(this string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0) return false;

                    char openBracket = stack.Pop();

                    if (c == ')' && openBracket != '(') return false;
                    if (c == '}' && openBracket != '{') return false;
                    if (c == ']' && openBracket != '[') return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
