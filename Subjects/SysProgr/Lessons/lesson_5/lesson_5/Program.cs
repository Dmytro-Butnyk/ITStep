using static System.Console;

Random rand = new Random();
// task 1
/*
// Starting a task using the "Start"
Task task1 = new Task(() => {
    WriteLine("Current time and date (Task.Start): " + DateTime.Now);
});
task1.Start();

// Starting a task using the "Task.Factory.StartNew" method.
Task task2 = Task.Factory.StartNew(() => {
    WriteLine("Current time and date (Task.Factory.StartNew): " + DateTime.Now);
});

// Starting a task using the "Task.Run" method.
Task task3 = Task.Run(() => {
    WriteLine("Current time and date (Task.Run): " + DateTime.Now);
});

// Wait for all tasks to complete.
Task.WaitAll(task1, task2, task3);
*/

// task 2
/*
Task task = new(() =>
{
    for(var i = 0; i <= 1000; ++i)
    {
        if (IsPrime(i))
        {
            WriteLine(i);
        }
    }
});
task.Start();
task.Wait();
*/

// task 3
/*
int countPrim = 0;

Task task = new(() =>
{
    for (var i = rand.Next(1,500); i <= rand.Next(500, 1000); ++i)
    {
        if (IsPrime(i))
        {
            WriteLine(i);
            countPrim++;
        }
    }
});
task.Start();
task.Wait();

WriteLine("Count of primary numbers: " + countPrim);
*/

// task 4
WriteLine("Enter start of the range (0 - 10000):");
int start = int.Parse(ReadLine());
WriteLine("Enter end of the range (0 - 10000):");
int end = int.Parse(ReadLine());

List<int> numbers = Enumerable.Range(0, 10000).ToList();

Task<object> task1 = new Task<object>(() =>
{
    {
         var res = numbers
        .Where(x => IsFibonacci(x) && x >= 213)
        .ToList();
        if(res != null)
            return res;

        return "No fibonacci";
    }
});

Task<object> task2 = new Task<object>(() =>
{
    {
        var res = numbers
       .Where(x => IsPrime(x) && x % 28 == 0 )
       .ToList();

        if( res.Count > 0)
            return res;

        return "No primes % 28 == 0";
    }
});

Task<object> task3 = new Task<object>(() =>
{
    return numbers
    .Where(n => n.ToString().Contains('1') && n.ToString().Contains('7'))
    .ToArray()
    .Average();
});

Task<object> task4 = new(() =>
{
    if (start > end)
        (start, end) = (end, start);

    return numbers.Where((x, i) =>
    i < end && i > start)
    .ToList()
    .Sum();
});

List<dynamic> tasks = [task1, task2, task3, task4];
List<object> results = new();
foreach (Task x in tasks)
{
    x.Start();
}
Task.WaitAll();

foreach (Task<dynamic> x in tasks)
{
    WriteLine(x.Id + ":");
        if (x.Result is List<int>)
        {
            WriteLine(string.Join(", ", x.Result));
        }
        else
            WriteLine(x.Result);
}


bool IsPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));

    for (int i = 3; i <= boundary; i += 2)
    {
        if (number % i == 0)
            return false;
    }

    return true;
}
static bool IsFibonacci(int n)
{
    int a = 0;
    int b = 1;

    while (b < n)
    {
        int temp = a;
        a = b;
        b = temp + b;
    }

    return n == b;
}