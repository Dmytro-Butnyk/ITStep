// See https://aka.ms/new-console-template for more information
using lesson_11;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Console;

OutputEncoding = Encoding.Unicode;
// task 1,2
/*
string text = "Завдання 1.\n" +
    "Створіть метод розширення (extension method) для підрахунку кількості речень у тексті.\n" +
    "Напишіть код для тестування методу.\n" +
    "Завдання 2.\n" +
    "Створіть метод розширення (extension method) для підрахунку у рядку кількості слів,\n" +
    "що починаються і закінчуються на один і той же символ (без урахування регістру сиволу).\n" +
    "Напишіть код для тестування методу.";
WriteLine(text);
WriteLine($"Number of sentences: {text.CountSentences()}");
WriteLine($"Number of words which first and last symbol is the same: {text.CountWordsWithSameStartEnd()}");
*/

// task 3

try
{
    Backpack backpack = new Backpack();
    backpack.itemAdded += item => WriteLine($"Item {item} added.");
    backpack.itemRemoved += item => WriteLine($"Item {item} removed.");
    backpack.BackpackOverloaded += totalWeight => {
        WriteLine($"Backpack overloaded! Backpack weight: {totalWeight} kg.");
        backpack.RemoveItem(backpack.Items.OrderBy(item => item.Value).Last().Key);
        };

    WriteLine(backpack);
    backpack.PutItem("Book", 2);
    backpack.RemoveItem("Laptop");
    backpack.CheckWeight(5);
    WriteLine();
    WriteLine(backpack);
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}

// task 4
/*
Person[] people = 
{
    new ("Dima", "Butnik", 18 ),
    new ("Ilya", "Ghrischenko", 19 ),
    new ("Nazar", "Ovsiuenko", 20 ),
};

WriteLine("Max age: " + people.MaxAge());
WriteLine("Min age: " + people.MinAge());
WriteLine("Average age: " + people.AverageAge());
*/
