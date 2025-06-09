// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using static System.Console;

// task 1
/*
WriteLine("Enter file path:");
string path = ReadLine();
if (!File.Exists(path))
{
    WriteLine("File does not exists!");
}
string content = File.ReadAllText(path);
WriteLine("File content:");
WriteLine(content);
*/

// task 2
/*
Random rand = new Random();
List<int> numbers = Enumerable
    .Range(0, 10000)
    .Select(_ => rand.Next())
    .ToList();

var evenNumbers = numbers.Where(n => n % 2 == 0);
var oddNumbers = numbers.Where(n => n % 2 != 0);

File.WriteAllLines("even.txt", evenNumbers.Select(n => n.ToString()));
File.WriteAllLines("odd.txt", oddNumbers.Select(n => n.ToString()));

WriteLine($"Even numbers count: {evenNumbers.Count()}");
WriteLine($"Odd numbers count: {oddNumbers.Count()}");
*/

// task 3
/*
Write("Enter the file path: ");
string filePath = ReadLine();

if (File.Exists(filePath))
{
    string fileContent = File.ReadAllText(filePath);

    Write("Enter a word to search for: ");
    string word = ReadLine();
    int wordCount = Regex.Matches(fileContent, word).Count;

    int digitCount = fileContent.Count(char.IsDigit);
    int sentenceCount = Regex.Matches(fileContent, @"[.!?]").Count;
    int upperCaseCount = fileContent.Count(char.IsUpper);
    int lowerCaseCount = fileContent.Count(char.IsLower);

    WriteLine($"Number of occurrences of the word '{word}': {wordCount}");
    WriteLine($"Number of digits: {digitCount}");
    WriteLine($"Number of sentences: {sentenceCount}");
    WriteLine($"Number of uppercase letters: {upperCaseCount}");
    WriteLine($"Number of lowercase letters: {lowerCaseCount}");
}
else
{
    WriteLine("Error: file does not exist.");
}
*/

// task 4
/*
Write("Enter the file path: ");
string filePath = ReadLine();

if (!File.Exists(filePath))
{
    WriteLine("Error: file does not exist.");
}

Write("Enter the copy file path: ");
string copyFilePath = ReadLine();

try
{
    File.Move(filePath, copyFilePath);
    WriteLine("File copied.");
}
catch (Exception ex)
{
    WriteLine($"Error during copying the file: {ex.Message}");
}
*/

// task 5
/*
Write("Enter original path: ");
string originalFilePath = ReadLine();

if (!File.Exists(originalFilePath))
{
    WriteLine("File does not exists.");
    return;
}

Write("Enter path where to move: ");
string newFilePath = ReadLine();

try
{
    File.Move(originalFilePath, newFilePath);
    WriteLine("File moved.");
}
catch (Exception ex)
{
    WriteLine($"Error during moving the file: {ex.Message}");
}
*/

// task 6

Write("Enter path to directory: ");
string sourceDirectory = ReadLine();

if (!Directory.Exists(sourceDirectory))
{
    WriteLine("Error: source directory does not exists.");
    return;
}

Write("Enter path where to copy the source directory: ");
string destinationDirectory = ReadLine();

try
{
    CopyDirectory(sourceDirectory, destinationDirectory);
    WriteLine("Directory has been copied.");
}
catch (Exception ex)
{
    WriteLine($"Error during the directory copying: {ex.Message}");
}
    

static void CopyDirectory(string sourceDirectory, string destinationDirectory)
{
    Directory.CreateDirectory(destinationDirectory);

    foreach (string file in Directory.GetFiles(sourceDirectory))
    {
        string fileName = Path.GetFileName(file);
        File.Copy(file, Path.Combine(destinationDirectory, fileName));
    }

    foreach (string directory in Directory.GetDirectories(sourceDirectory))
    {
        string directoryName = Path.GetFileName(directory);
        CopyDirectory(directory, Path.Combine(destinationDirectory, directoryName));
    }
}

ReadKey();