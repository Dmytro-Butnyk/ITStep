using static System.Console;
using hw_5;

class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Enter a file path or text for analysis:");
        string input = ReadLine();

        string text;
        if (File.Exists(input))
        {
            text = await File.ReadAllTextAsync(input);
        }
        else
        {
            text = input;
        }

        var report = new TextReport(text);
        await report.Analyze();

        WriteLine(report);

        WriteLine("Do you want to save the report to a file? (y/n)");
        if (ReadLine().ToLower() == "y")
        {
            await File.WriteAllTextAsync("report.txt", report.ToString());
            WriteLine("The report has been saved to report.txt");
        }
    }
}

