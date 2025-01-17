using System;
using System.Linq;
using System.Threading;
using static System.Console;

Random random = new Random();

// task 1

//List<int> numbers = Enumerable.Range(1, 1000).Select(_ => random.Next(-2370, 5000)).ToList();

//object lockObject = new object();

//new Thread(() =>
//{
//    int max;
//    lock (lockObject)
//    {
//        max = numbers
//        .Where((x, i) => i % 3 == 0 && i != 0)
//        .ToList()
//        .Max();
//        numbers[numbers.Count - 1] = max;
//    }
//    WriteLine($"Maximum number of numbers that can be a multiple of 3: {max}");
//}).Start();

//new Thread(() =>
//{
//    int min;
//    lock (lockObject)
//    {
//        min = numbers
//        .Where((x, i) => x >= 100 && x <= 999 && i % 3 == 0 && i != 0)
//        .ToList()
//        .Min();
//        numbers[0] = min;
//    }
//    WriteLine($"Minimum of the middles of three-digit numbers whose values ​​are divisible by 7: {min}");
//}).Start ();

//new Thread(() =>
//{
//    double average;
//    lock (lockObject)
//    {
//        average = numbers
//        .Skip(numbers.Count / 2)
//        .Average();
//        numbers[numbers.Count / 2] = (int)average;
//    }
//    WriteLine($"The arithmetic mean of the numbers of the other half of the collection: {average}");
//}).Start () ;

//Thread.Sleep (1000);
//WriteLine(string.Join(", ", numbers));

// task 2


