// See https://aka.ms/new-console-template for more information
using static System.Console;
using lesson_5;
using System.Reflection;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

// task 1
static int StringToInt(string s)
{
    if (s == string.Empty) {
        throw new ArgumentException("Null entries!");
    }
    s = s.Replace(" ", "");
    int num;
    while (!int.TryParse(s, out num))
    {
        WriteLine("Wrong number! Input symbols: (0 - 9)");
        s = ReadLine();
    }
    return num;
}

// task 2
static int BinaryToDecimal(string s)
{
    try
    {
        int num = Convert.ToInt32(s, 2);
        Console.WriteLine($"Decimal equivalent: {num}");
        return num;
    }
    catch (Exception ex)
    {
        WriteLine($"Error: {ex.Message}");
        return 0;
    }
}

// task 4
static int MultiplyOperations(string s)
{
    foreach(var it in s)
    {
        if (!char.IsDigit(it) && it != '*') throw new FormatException("Wrong values or operator");
    }
    string[] numbers = s.Split('*', StringSplitOptions.RemoveEmptyEntries);
    int res = 1;
    foreach(var it in numbers)
    {
        res *= int.Parse(it);
    }

    return res;
}
string s;
// task 1 

//Console.WriteLine("Enter symbols (0 - 9) (number):");
//s = Console.ReadLine();
//Console.WriteLine("Your number: " + StringToInt(s));


// task 2

//WriteLine("Enter binary number:");
//s = ReadLine();
//WriteLine("The number: " + BinaryToDecimal(s));

// task 3

//CreditCard card = new();
//card.InputData();
//card.Show();

// task 4
try
{
    WriteLine("Enter math operation: ");
    s = ReadLine();
    WriteLine("Result: " + MultiplyOperations(s));
}
catch (FormatException fe) { WriteLine("Error: " + fe.Message); }


