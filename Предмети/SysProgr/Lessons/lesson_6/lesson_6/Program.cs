using System.Security.AccessControl;
using static System.Console;


// task 1, 2
/*
Write("Enter a number: ");
int number; 
_ = int.TryParse(ReadLine(), out number);
ulong factorial = Factorial(number);
WriteLine($"Factorial of {number} equals to {factorial}");

int digitCount = 0;
int digitSum = 0;
Parallel.Invoke(
    () => digitCount = CountDigits(number),
    () => digitSum = SumDigits(number)
);
WriteLine($"The number of digits in {number} is {digitCount}");
WriteLine($"The sum of the digits in {number} is {digitSum}");


static int CountDigits(int number)
{
    return number.ToString().Length;
}

static int SumDigits(int number)
{
    return number.ToString().Sum(c => c - '0');
}
*/

// task 3
/*
int start, end;

Write("Enter a start of range: ");
int.TryParse(ReadLine(), out start);
Write("Enter an end of range: ");
int.TryParse(ReadLine(), out end);

if(start > end) 
    (start, end) = (end, start);

using (StreamWriter file = new StreamWriter("MultiTable.txt"))
{
    Parallel.For(start, end + 1, i =>
    {
        lock (file)
        {
            Parallel.For(1, 11, j =>
            {
                file.WriteLine($"{i}*{j} = {i * j}");
            });
        }
            file.WriteLine();
    }); 
}
*/

// task 4

List<ulong> factorials = new();

List<string> nums = File.ReadAllLines("numbers.txt").ToList();

Parallel.ForEach(nums, num =>
{
    int number;
    int.TryParse(num, out number);
    lock (factorials)
    {
        factorials.Add(Factorial(number));
    }
});

foreach (var factorial in factorials)
{
    WriteLine(factorial);
}
ulong Factorial(int number)
{
    if (number == 0) return 1;
    ulong result = 1;
    Parallel.For(1, number + 1, i => { result *= (ulong)i; });
    return result;
}


// task 5

List<int> numbers = File.ReadAllLines("numbers.txt").Select(int.Parse).ToList();

var sortedNumbers = numbers.AsParallel().AsOrdered().ToList();

var sum = numbers.AsParallel().Sum();

var maxAbs = numbers.AsParallel().Max(Math.Abs);

var minMultipleOf7 = numbers.AsParallel().Where(n => n % 7 == 0).Min();

WriteLine($"Sorted Numbers: {string.Join(", ", sortedNumbers)}");
WriteLine($"Sum: {sum}");
WriteLine($"Max (Absolute): {maxAbs}");
WriteLine($"Min (Multiple of 7): {minMultipleOf7}");