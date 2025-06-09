using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_11
{
    public static class StringExtensions
    {
        public static int CountSentences(this string text)
        {
            return text.Count(c => c == '.' ||
            c == '?' || c == '!' || c == ';');
        }
        public static int CountWordsWithSameStartEnd(this string text)
        {
            return text.Split(" ,.!?:;()\"'".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Count(word => word.Length > 1 &&
                char.ToLower(word.First()) == char.ToLower(word.Last()));
        }
    }
}
