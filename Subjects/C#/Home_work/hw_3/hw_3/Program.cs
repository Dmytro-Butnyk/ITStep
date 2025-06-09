// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.Text.RegularExpressions;

// task 1
static void EncodeString(ref string s, int key)
{
    char[] chars = s.ToCharArray();

    for (int i = 0; i < chars.Length; i++)
    {
        if (char.IsUpper(chars[i]))
        {
            chars[i] = (char)(((chars[i] - 'A' + key) % 26 + 26) % 26 + 'A');
        }
        else if (char.IsLower(chars[i]))
        {
            chars[i] = (char)(((chars[i] - 'a' + key) % 26 + 26) % 26 + 'a');
        }
    }

    s = new string(chars);
}

static void DecodeString(ref string s, int key, int input)
{
    if (input != key)
    {
        Console.WriteLine("Wrong key.");
        return;
    }

    char[] chars = s.ToCharArray();

    for (int i = 0; i < chars.Length; i++)
    {
        if (char.IsUpper(chars[i]))
        {
            chars[i] = (char)(((chars[i] - 'A' - key) % 26 + 26) % 26 + 'A');
        }
        else if (char.IsLower(chars[i]))
        {
            chars[i] = (char)(((chars[i] - 'a' - key) % 26 + 26) % 26 + 'a');
        }
    }

    s = new string(chars);
}

// task 2
static int MathExpression(string s)
{
    try
    {
        string[] elements = s.Split("-=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        if (elements.Length < 2)
        {
            Console.WriteLine("Invalid math expression format.");
            return 0;
        }

        int result = int.Parse(elements[0]);
        int currentIndex = elements[0].Length;

        for (int i = 1; i < elements.Length; i++)
        {
            char op = s[currentIndex];
            int operand = int.Parse(elements[i]);

            if (op == '+')
            {
                result += operand;
            }
            else if (op == '-')
            {
                result -= operand;
            }

            currentIndex += elements[i].Length + 1;
        }

        return result;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        return 0;
    }
}

// task 1
/*
string s = Console.ReadLine();
int key = int.Parse(Console.ReadLine());

EncodeString(ref s, key);
Console.WriteLine("Encoded string: " + s);

int value = int.Parse(Console.ReadLine());
DecodeString(ref s, key, value);
Console.WriteLine("Decoded string: " + s);
*/

// task 2
/*
string s;
Console.WriteLine("Enter math expression:");
s = Console.ReadLine();
Console.WriteLine("Result: " + MathExpression(s));
*/

// task 3
//string pattern = @"^(16[0-9]{2}|1[7-9][0-9]{2}|[2-9][0-9]{3})/(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])$";
//Regex regex = new Regex(pattern);

// task 4
//string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d_]{8,}$";
//Regex regex = new Regex(pattern);

// task 5
string text = @"To be, or not to be, that is the question,
Whether 'tis nobler in the mind to suffer
The slings and arrows of outrageous fortune,
Or to take arms against a sea of troubles,
And by opposing end them? To die: to sleep;
No more; and by a sleep to say we end
The heart-ache and the thousand natural shocks
That flesh is heir to, 'tis a consummation
Devoutly to be wish'd. To die, to sleep";

string forbiddenWord = "be";

string pattern = @"\b" + forbiddenWord + @"\b";
string replacement = "***";

string newText = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase);


Console.WriteLine(newText);
Console.WriteLine($"Forbidden word {forbiddenWord} has changed.");