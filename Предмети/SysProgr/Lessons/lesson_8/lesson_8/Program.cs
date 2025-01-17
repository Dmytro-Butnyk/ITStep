using MyLibrary;
using static System.Console;

// task 1

InfoClass.ShowMessage("task 1 completed");

// task 2

if (LeapYearClass.IsLeapYear(2024))
    WriteLine("True");
else
    WriteLine("False");

// task 3

WriteLine("Min: " + MathClass.Min(1, 3, 4));
WriteLine("Max: " + MathClass.Max(1, 3, 4));
WriteLine("Sum: " + MathClass.Sum(1, 3, 4));

// task 4 

if (UserClass.IsValidName("Dima"))
    WriteLine("Correct name");
if (UserClass.IsValidAge("18"))
    WriteLine("Correct age");
if (UserClass.IsValidPhone("+38(067)123-45-67"))
    WriteLine("Correct number");
if (UserClass.IsValidEmail("email@gmail.com"))
    WriteLine("Correct email");

// task 5

// також перевірив у голові...

