using static System.Console;

// task 1
/*
WriteLine("Enter the start number of the range:");
int start = int.Parse(ReadLine());

WriteLine("Enter the end number of the range:");
int end = int.Parse(ReadLine());

Thread thread = new Thread(() => PrintNumbers(start, end));
thread.Start();

void PrintNumbers(int start, int end)
{
    for (int i = start; i <= end; i++)
    {
        WriteLine(i);
    }
}
*/

// task 2

Random random = new Random();
List<int> numbers = Enumerable.Range(1, 10000)
    .Select(_ => random.Next(1, 1000))
    .ToList();
//WriteLine(string.Join(", ", numbers));


Thread maxOddThread = new Thread(() =>
{
    int maxOdd = numbers.Where(n => n % 2 != 0).Max();
    WriteLine("Max Odd: " + maxOdd);
});
maxOddThread.Start();

Thread minPrimeThread = new Thread(() =>
{
    int minPrime = numbers.Where(IsPrime).Min();
    WriteLine("Min Prime: " + minPrime);
});
minPrimeThread.Start();

Thread avgNonPrimeThread = new Thread(() =>
{
    double avgNonPrime = numbers.Where(n => !IsPrime(n)).Average();
    WriteLine("Average Non-Prime: " + avgNonPrime);
});
avgNonPrimeThread.Start();

bool IsPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));

    for (int i = 3; i <= boundary; i += 2)
        if (number % i == 0)
            return false;

    return true;
}


// task 3

Thread numbersThread = new Thread(GenerateNumbers);
Thread lettersThread = new Thread(GenerateLetters);
Thread symbolsThread = new Thread(GenerateSymbols);

numbersThread.Priority = ThreadPriority.Highest;
lettersThread.Priority = ThreadPriority.Normal;
symbolsThread.Priority = ThreadPriority.Lowest;

numbersThread.Start();
lettersThread.Start();
symbolsThread.Start();

numbersThread.Join();
lettersThread.Join();
symbolsThread.Join();

void GenerateNumbers()
{
    for (int i = 1; i <= 10; i++)
    {
        WriteLine("Numbers Thread: " + i);
        Thread.Sleep(1000);
    }
}

void GenerateLetters()
{
    for (char c = 'A'; c <= 'J'; c++)
    {
        WriteLine("Letters Thread: " + c);
        Thread.Sleep(1000);
    }
}

void GenerateSymbols()
{
    char[] symbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };

    foreach (char symbol in symbols)
    {
        WriteLine("Symbols Thread: " + symbol);
        Thread.Sleep(1000);
    }
}
