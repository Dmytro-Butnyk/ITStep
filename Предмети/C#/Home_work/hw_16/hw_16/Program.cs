// See https://aka.ms/new-console-template for more information
using hw_16;
using System.Linq;
using static System.Console;
Random rand = new();

// tasks 1 - 3
#region
/*
// task 1
List<int> task1 = Enumerable.Range(0, 10)
    .Select(_ => rand.Next(500, 10000))
    .ToList();
// #
WriteLine("task 1");
task1.ForEach(x => Write(x + " "));
// 1
WriteLine($"\n#1 {(ulong)task1
    .Aggregate(1, (total, number) => total * number)}");
// 2
WriteLine($"#2 {task1.Count}");
// 3
WriteLine($"#3 {task1
    .Count(x => x % 9 == 0)}");
// 4
WriteLine($"#4 {task1
    .Count(x => x % 7 == 0 && x > 945)}");
// 5
WriteLine($"#5 {(long)task1.Sum()}");
// 6
WriteLine($"#6 {task1
    .Where(x => x % 2 == 0)
    .Sum()}");
// 7 
WriteLine($"#7 {task1.Min()}");
// 8
WriteLine($"#8 {task1.Max()}");
// 9
WriteLine($"#9 {task1.Average()}");

// task 2 
// #
WriteLine("task 2");
task1.ForEach(x => Write(x + " "));

// 1
WriteLine($"\n#1");
task1.OrderBy(x => -x)
    .Take(3)
    .ToList()
    .ForEach(x => Write(x + " "));
// 2
WriteLine($"\n#2");
task1.OrderBy(x => x)
    .Take(3)
    .ToList()
    .ForEach(x => Write(x + " "));
WriteLine();

// task 3
// #
WriteLine("task 3");
task1.ForEach(x => Write(x + " "));
WriteLine();

// 1
var numStat = task1
    .GroupBy(n => n)
    .ToDictionary(group => group.Key, group => group.Count());
WriteLine("#1");
foreach (var pair in numStat)
{
    WriteLine($"{pair.Key} - {pair.Value}");
}
// 2
var numEvenStat = task1
    .Where(x => x % 2 == 0)
    .GroupBy(n => n)
    .ToDictionary(group => group.Key, group => group.Count());
WriteLine("#2");
foreach (var pair in numEvenStat)
{
    WriteLine($"{pair.Key} - {pair.Value}");
}
// 3
var numEvenOddStat = task1
    .GroupBy(x => x % 2 == 0)
    .ToDictionary(group => group.Key, group => group.Count());
WriteLine("#2");
foreach (var pair in numEvenOddStat)
{
    WriteLine($"{pair.Key} - {pair.Value}");
}
*/
#endregion

// task 4

List<Laptop> laptops = new List<Laptop>
{
    new Laptop("Model1", "Manufacturer1", 2.5, 4, 1000m),
    new Laptop("Model2", "Manufacturer2", 3.1, 8, 1500m),
    new Laptop("Model3", "Manufacturer1", 2.8, 6, 1200m),
    new Laptop("Model4", "Manufacturer3", 3.5, 8, 2000m),
    new Laptop("Model5", "Manufacturer2", 2.3, 4, 900m)
};

// 1
int laptopCount = laptops.Count;

// 2
decimal inputPrice = 1000m; 
int expensiveLaptopsCount = laptops
    .Count(l => l.Price > inputPrice);

// 3
decimal lower = 500m, upper = 1500m;
int laptopsInRangeCount = laptops
    .Count(l => l.Price >= lower && l.Price <= upper);

// 4
string manufacturer = "Manufacturer2"; 
int manufacturerLaptopsCount = laptops
    .Count(l => l.Manufacturer == manufacturer);

// 5
Laptop cheapestLaptop = laptops
    .OrderBy(l => l.Price).FirstOrDefault();

// 6
Laptop mostExpensiveLaptop = laptops
    .OrderByDescending(l => l.Price)
    .FirstOrDefault();

// 7
Laptop slowestLaptop = laptops
    .OrderBy(l => l.Quantity)
    .FirstOrDefault();

// 8
decimal averagePrice = laptops
    .Average(l => l.Price);

// 9
var manufacturerCounts = laptops
    .GroupBy(l => l.Manufacturer)
    .Select(g => new { Manufacturer = g.Key, Count = g.Count() });

// 10
var modelCounts = laptops
    .GroupBy(l => l.Model)
    .Select(g => new { Model = g.Key, Count = g.Count() });

// 11
var top5ExpensiveLaptops = laptops
    .OrderByDescending(l => l.Price)
    .Take(5);

// 12
var top5CheapestLaptops = laptops
    .OrderBy(l => l.Price)
    .Take(5);

// task 5

List<int> numbers = new() { 1, 2, 8, -1, 4, 2, 7, 9, 15, 5};
// #
WriteLine("task 5");
numbers
    .ForEach(x => Write(x + " "));
WriteLine();

// 1
int maxLength = numbers.Select((num, index) =>
               numbers.Skip(index)
                      .TakeWhile((n, i) => i == 0 || numbers[index + i] > numbers[index + i - 1])
                      .Count())
                      .Max();

WriteLine($"#1 {maxLength}");

// task 6

string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };

// 1
bool moreThanThree = lastNames.All(s => s.Length > 3);

// 2
bool betweenThreeAndTen = lastNames.All(s => s.Length > 3 && s.Length < 10);

// 3
bool startsWithW = lastNames.Any(s => s.StartsWith("W"));

// 4
bool endsWithY = lastNames.Any(s => s.EndsWith("Y"));

// 5
bool containsOrange = lastNames.Contains("Orange");

// 6
string firstSurnameWithLength6 = lastNames.FirstOrDefault(s => s.Length == 6);

// 7
string lastSurnameWithLengthLessThan15 = lastNames.LastOrDefault(s => s.Length < 15);

// task 7

// task 8
WriteLine("Task 8");

int maxLenOfPos = numbers.Select((num, index) =>
               numbers.Skip(index)
                      .TakeWhile((n, i) => numbers[index + i] >= 0)
                      .Count())
                      .Max();

WriteLine($"#1 {maxLenOfPos}");
