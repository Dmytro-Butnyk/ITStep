using static System.Console;

// task 1

int lowerBound = 2; 
int upperBound = 100;

Thread thread = new Thread(() =>
{
    for (int i = lowerBound; i <= upperBound; i++)
    {
        if (IsPrime(i))
        {
            WriteLine(i);
        }
    }
});

// task 2

int count = 10;

Thread fibonacciThread = new Thread(() =>
{
    for (int i = 0; i < count; i++)
    {
        WriteLine(Fibonacci(i));
    }
});

thread.Start();
fibonacciThread.Start();

thread.Join();
fibonacciThread.Join();


static bool IsPrime(int number)
{
    if (number < 2) return false;

    for (int i = 2; i * i <= number; i++)
    {
        if (number % i == 0) return false;
    }

    return true;
}

static int Fibonacci(int n)
{
    if (n <= 1) return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

// task 3

//string filePath = "test.txt"; 
//string wordToFind = "test";

//string text = await File.ReadAllTextAsync(filePath);
//int wordCount = text.Split(new[] { wordToFind }, StringSplitOptions.None).Length - 1;

//WriteLine($"The word '{wordToFind}' apeared {wordCount} times.");