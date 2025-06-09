// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
using static System.Console;
using hw_5;
using System.Security.Cryptography.X509Certificates;
// task 1
/*
while (true)
{
    WriteLine("Choose the converting way:");
    WriteLine("1. From decimal to binary");
    WriteLine("2. From binary to decimal");
    WriteLine("3. Exit");
    Write("Your choice: ");
    string choice = ReadLine();

    switch (choice)
    {
        case "1":
            Write("Enter decimal number: ");
            string decInput = ReadLine();
            if (int.TryParse(decInput, out int decNumber))
            {
                WriteLine("Binary format: " + Convert.ToString(decNumber, 2));
            }
            else
            {
                WriteLine("Wrong value! Try again.");
            }
            break;
        case "2":
            Write("Enter binary number: ");
            string binInput = ReadLine();
            try
            {
                int binNumber = Convert.ToInt32(binInput, 2);
                WriteLine("Decimal format: " + binNumber);
            }
            catch (Exception)
            {
                WriteLine("Wrong value! Try again.");
            }
            break;
        case "3":
            return;
        default:
            WriteLine("Wrong value! Try again.");
            break;
    }
    ReadKey();
    Clear();
}
*/

// task 2
/*
while (true)
{
    WriteLine("Enter number (one - nine) or '0' to exit:");
    string input = ReadLine();
    if(input == "0")
    {
        return;
    }
    if (Enum.TryParse(input, out Numbers number))
    {
        WriteLine("Your number: " + (int)number);
    }
    else
    {
        WriteLine("Wrong input.");
    }
}
enum Numbers { one = 1, two, three, four, five,
    six, seven, eight, nine }
*/

// task 3
/*
ForeignPassport passport1 = new("343234", "Butnyk Dmytro", "2023/02/04");
WriteLine(passport1);
ForeignPassport passport2 = new();
passport2.Initiate();
WriteLine(passport2);
*/
try
{
    while (true)
    {
        WriteLine("Input operation (x>y)\n" +
            "operators required (>, <, <=, >=, ==, !=):");
        OperatorCalc op = new(ReadLine());
        if (op != null && op.OperationResult())
        {
            WriteLine("True");
        }
        else
        {
            WriteLine("False");
        }
        WriteLine("0 - exit, else - continue");
        if (ReadLine() == "0") return;
    }
}
catch(Exception ex)
{
    WriteLine(ex.Message);
}