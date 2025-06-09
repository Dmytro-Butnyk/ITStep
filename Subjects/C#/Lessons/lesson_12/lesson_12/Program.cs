// See https://aka.ms/new-console-template for more information
using lesson_12;
using System.Xml.Linq;
using static System.Console;

// task 1
List<Worker> workers = new List<Worker>();

while (true)
{
    WriteLine("1 - show workers\n" +
        "2 - add worker\n" +
        "3 - delete worker\n" +
        "4 - change worker\n" +
        "5 - search worker by name\n" +
        "6 - sort by position\n" +
        "0 - exit:");

    switch (ReadLine())
    {
        case "1":
            {
                int i = 0;
                WriteLine("Workers:");
                foreach (Worker worker in workers)
                {
                    WriteLine(i + ") " + worker);
                }
                break;
            }
        case "2":
            {
                WriteLine("Enter new name, position, salary, email\n" +
                "one by one after 'enter':");
                WorkerTools.AddWorker(ReadLine(), ReadLine(), decimal.Parse(ReadLine()), ReadLine(), ref workers);

                break;
            }
        case "3":
            {
                WriteLine("Enter index of worker:");
                WorkerTools.DeleteWorker(ref workers, int.Parse(ReadLine()));

                break;
            }
        case "4":
            {
                WriteLine("Enter index:");
                WorkerTools.ChangeWorker(int.Parse(ReadLine()), ref workers);

                break;
            }
        case "5":
            {
                WriteLine("Enter worker name:");
                WorkerTools.FindByName(ReadLine(), workers);
                break;
            }
        case "6":
            {
                WorkerTools.SortByPosition(ref workers);

                break;
            }
        case "0":
            {
                Environment.Exit(0);
                break;
            }
        default:
            {
                break;
            }
    }
}





