// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Reflection;
using static System.Console;

// task 1
void DrawSquare(int length, char symbol)
{ 
    for(int i = 0; i < length; ++i)
    {
       WriteLine(string.Concat(Enumerable.Repeat(symbol+" ", 5)));
    }
}
// task 2
bool IsPalindrome(string word)
{
    string reversedWord = new string(word.ToCharArray().Reverse().ToArray());
    if(word == reversedWord) return true;
    return false;
}

// task 3
void FilterArray(ref int[] arr, int[] filter, out int numberExceptions)
{
    int[] newArr = arr.Except(filter).ToArray();
    numberExceptions = arr.Length - newArr.Length;
    arr = newArr;
}


// task 1
//int a;
//char ch;
//WriteLine("Enter length:");
//a = int.Parse(Console.ReadLine());
//WriteLine("Enter symbol:");
//ch = char.Parse(Console.ReadLine());
//DrawSquare(a, ch);

// task 2
//WriteLine("Enter the word to check is palindrome:");
//if (IsPalindrome(ReadLine()))
//{
//    WriteLine("Yes");
//}
//else
//{
//    WriteLine("No");
//}

// task 3
//int[] arr = { 2, 4, 4, 8, 5};
//int[] filter = { 4, 5 };

//WriteLine($"Old array:");
//foreach (int it in arr) Write($"{it, 3}"); WriteLine();
//WriteLine($"Filter array:"); 
//foreach (int it in arr) Write($"{it,3}"); WriteLine();

//int nEx;
//FilterArray(ref arr, filter, out nEx);

//WriteLine($"Filtered array:");
//foreach (int it in arr) Write($"{it,3}"); WriteLine();
//WriteLine($"Number exceptions: {nEx}");