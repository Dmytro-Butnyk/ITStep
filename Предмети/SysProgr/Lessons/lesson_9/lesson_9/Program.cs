using static System.Console;


Write("Enter directory path: ");
string dirPath = ReadLine();

Write("Enter word to search: ");
string wordToFind = ReadLine();

string[] files = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);

Task<int>[] results = new Task<int>[files.Length];

for (int i = 0; i < results.Length; i++)
{
    results[i] = WordCountInFileAsync(files[i], wordToFind);
    WriteLine($"File path: {files[i]}");
}
await Task.WhenAll(results);

for(int i = 0; i < results.Length; i++)
{
    WriteLine($"File name: {Path.GetFileName(files[i])}");
    WriteLine($"Number of occurrences of a word: {results[i].Result}");
    WriteLine();
}


static async Task<int> WordCountInFileAsync(string filePath, string word)
{
    await Task.Delay(1000);
    string content = await File.ReadAllTextAsync(filePath);
    return content.Split(new[] { word }, StringSplitOptions.None).Length - 1;
}

