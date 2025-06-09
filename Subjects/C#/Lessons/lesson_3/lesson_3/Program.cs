using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

// task 1
static int NumberWords(string s)
{
    return s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
}
static void UpperLetterWords(string s)
{
    string[] w = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    for(int i = 0; i < w.Length; i++)
    {
        if (char.IsUpper(w[i][0]))
        {
            Console.WriteLine(w[i]);
        }
    }
}
static void LastAWords(string s)
{
    string[] w = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    for (int i = 0; i < w.Length; i++)
    {
        if (w[i][w[i].Length-1] == 'a' || w[i][w[i].Length - 1] == 'A')
        {
            Console.WriteLine(w[i]);
        }
    }
}
// task 2
static void ReverseAllWords(ref string s)
{
  string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = new string(words[i].Reverse().ToArray());
        }

        s = string.Join(" ", words);
}
// task 3
static void StartSentenceWithUpper(ref string s)
{
    string[] sentences = s.Split(".!?".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < sentences.Length; i++)
    {
        sentences[i] = sentences[i].Trim();

        sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
    }

    s = string.Join(". ", sentences);
}
// task 4
static int NumberSubstrings(string s, string sub)

{
    int occurrences = 0;
    int index = s.IndexOf(sub, StringComparison.OrdinalIgnoreCase);

    while (index != -1)
    {
        occurrences++;
        index = s.IndexOf(sub, index + sub.Length, StringComparison.OrdinalIgnoreCase);
    }
    return occurrences;
}
// task 5
static bool IsValidColor(string s)
{
    string ColorPattern = @"^#(?:[0-9a-fA-F]{3}){1,2}$";
    Regex regex = new Regex(ColorPattern);

    return regex.IsMatch(s);
}

// task 1

string s;
Console.WriteLine("Enter sentence:");
s = Console.ReadLine();

/*
Console.WriteLine($"Number of words: {NumberWords(s)}");
Console.WriteLine("Words start with upper letter:");
UpperLetterWords(s);
Console.WriteLine("Words end with 'A':");
LastAWords(s);
*/

// task 2
/*
ReverseAllWords(ref s);
Console.WriteLine($"Reversed words sentence: {s}");
*/

// task 3
/*
StartSentenceWithUpper(ref s);
Console.WriteLine("Redacted text: " + s);
*/

// task 4
/*
string sub;
Console.WriteLine("Enter substring to search: ");
sub = Console.ReadLine();

Console.WriteLine($"Result of searching: {NumberSubstrings(s, sub)}");
*/

// task 5

if (IsValidColor(s))
{
    Console.WriteLine("Valid color.");
}
else
{
    Console.WriteLine("Wrong color.");
}

