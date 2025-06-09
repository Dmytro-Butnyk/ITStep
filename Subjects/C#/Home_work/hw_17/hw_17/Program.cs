// task 1

//Random rand = new Random();
//List<int> numbers = new List<int>();
//for (int i = 0; i < 100; i++)
//{
//    numbers.Add(rand.Next(1, 101));
//}

//List<int> primes = numbers.Where(n => IsPrime(n)).ToList();
//List<int> fibonaccis = numbers.Where(n => IsFibonacci(n)).ToList();

//File.WriteAllLines("primes.txt", primes.Select(p => p.ToString()));
//File.WriteAllLines("fibonaccis.txt", fibonaccis.Select(f => f.ToString()));

//Console.WriteLine($"Generated 100 random integers. {primes.Count} prime numbers and {fibonaccis.Count} Fibonacci numbers were found and saved into separate files.");

// task 2

//string filePath = "test1.txt";
//string text = File.ReadAllText(filePath);
//string wordToFind = "oldWord";
//string wordToReplace = "newWord";

//text = text.Replace(wordToFind, wordToReplace);
//File.WriteAllText(filePath, text);

//Console.WriteLine($"All occurrences of '{wordToFind}' in the file '{filePath}' have been replaced with '{wordToReplace}'.");

// task 3

//string textFilePath = "text.txt";
//string wordsFilePath = "words.txt";

//string text1 = File.ReadAllText(textFilePath);
//string[] words = File.ReadAllLines(wordsFilePath);

//foreach (string word in words)
//{
//    text1 = text1.Replace(word, new string('*', word.Length));
//}

//File.WriteAllText(textFilePath, text1);

//Console.WriteLine($"All words in the file '{textFilePath}' that are listed in the file '{wordsFilePath}' have been replaced with '*'.");

// task 4

//string directoryPath = @"O:\DataForUser";
//string fileExtension = "*.txt";

//string[] files = Directory.GetFiles(directoryPath, fileExtension, SearchOption.AllDirectories);

//foreach (string file in files)
//{
//    Console.WriteLine(file);
//    File.Delete(file);
//}

// task 5

Random random = new();
List<int> list = Enumerable.Range(0, 100000)
    .Select(_ => random.Next(-100000, 100000))
    .ToList();

File.WriteAllLines("numbers.txt", list.Select(n => n.ToString()));

string filePath = "numbers.txt";
int[] numbers = File.ReadAllLines(filePath).Select(int.Parse).ToArray();

int positiveCount = numbers.Count(n => n > 0);
int negativeCount = numbers.Count(n => n < 0);
int twoDigitCount = numbers.Count(n => n >= 10 && n <= 99);
int fiveDigitCount = numbers.Count(n => n >= 10000 && n <= 99999);

Console.WriteLine($"Positive numbers: {positiveCount}");
Console.WriteLine($"Negative numbers: {negativeCount}");
Console.WriteLine($"Two-digit numbers: {twoDigitCount}");
Console.WriteLine($"Five-digit numbers: {fiveDigitCount}");

File.WriteAllLines("positive.txt", numbers.Where(n => n > 0).Select(n => n.ToString()));
File.WriteAllLines("negative.txt", numbers.Where(n => n < 0).Select(n => n.ToString()));

// 

string sourceDirectory = @"O:\SourceDirectory";
string destinationDirectory = @"O:\DestinationDirectory";

try
{
    Directory.Move(sourceDirectory, destinationDirectory);
    Console.WriteLine($"Successfully moved the directory from '{sourceDirectory}' to '{destinationDirectory}'.");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to move the directory due to an error: {ex.Message}");
}

// methods
#region
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
bool IsFibonacci(int number)
{
    int a = 0;
    int b = 1;
    while (number > b)
    {
        int temp = a;
        a = b;
        b = temp + b;
    }
    return number == b;
}
#endregion