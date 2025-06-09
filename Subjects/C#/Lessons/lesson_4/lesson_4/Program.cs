using lesson_4;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

static void swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}
static bool Check<T>(out T num) where T : struct
{
    num = default(T);
    try
    {
        string input = Console.ReadLine();
        num = (T)Convert.ChangeType(input, typeof(T));
        return true;
    }
    catch
    {
        Console.WriteLine("Wrong value!");
        return false;
    }
}
// task 1
static int GetProductInRange(int s, int e)
{
    if(s > e)
    {
        swap(ref s, ref e);
    }
    int res = 1;
    for(int i = s+1; i < e; ++i)
    {
        res *= i;
    }
    return res;
}
// task 2
static bool IsFibonacci(ref int n)
{
    int a = 0, b = 1, c;
    for(int i = 0; i <= n; ++i)
    {
        c = a + b;
        a = b; 
        b = c;
        if(c == n)
        {
            return true;
        }
        else if(c > n)
        {
            n = c;
            return false;
        }
    }
    return false;
}
// task 3
static void AddRowOfSums(ref int[][] arr)
{
    int[] sum = new int[arr.Length];
    int i = 0;
    foreach(var row in arr)
    {
        sum[i] = row.Sum();
        ++i;
    }
    Array.Resize(ref arr, arr.Length+1);
    arr[arr.Length-1] = sum;
}
// task 4
static void DeleteSpaces(ref string s)
{
    string[] newS = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    for(int i = 0; i < newS.Length; ++i)
    {
        for(int j = 1; j < newS[i].Length; ++j)
        {
            if (newS[i][0] == newS[i][j])
            {
                newS[i] = newS[i].ToUpper();
            }
        }
    }
    s = string.Join(" ", newS);
}

Random r = new Random();


// task 1
/*
int a = 4, b = 8;
Console.WriteLine($"Product of {a} and {b} = {GetProductInRange(a, b)}");
*/
// task 2
/*
int a = 35;

if(IsFibonacci(ref a))
{
    Console.WriteLine($"The number \"{a}\" is Fibonacci number!");
}
else
{
    Console.WriteLine($"The number is not Fibonacci number!\n" +
        $"The number redacted to {a}.");
}
*/
// task 3
/*
int size = 5;
int[][] arr = new int[size][];
for(int i = 0; i < size; ++i)
{
    arr[i] = new int[r.Next(2,8)];
}
for(int i = 0; i < size; ++i)
{
    for (int j = 0; j < arr[i].Length; ++j)
    {
        arr[i][j] = r.Next(-10,20);
        Console.Write($"{arr[i][j],4}");
    }
    Console.WriteLine();
}
AddRowOfSums(ref arr);
Console.WriteLine("New array:");
foreach (var row in arr)
{
    foreach (var col in row)
    {
        Console.Write($"{col,4}");
    }
    Console.WriteLine();
}
*/
// task 4
/*
string s;
Console.WriteLine("Enter string:");
s = Console.ReadLine();
DeleteSpaces(ref s);
Console.WriteLine("Redacted string: " + s);
*/
