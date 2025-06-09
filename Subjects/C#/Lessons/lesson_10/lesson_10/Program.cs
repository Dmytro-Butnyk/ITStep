// See https://aka.ms/new-console-template for more information

using lesson_10;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

static int ValidateINT()
{
    int number;
    if (int.TryParse(ReadLine(), out number))
    {
        return number;
    }
    else {
        WriteLine("Wrong value. Now now equals to zero");
        return 0; 
    }
}
void Analyze(int n, Predicate<int> method)
{
    if (method(n))
    {
        WriteLine($"Number {n} - yes");
    }
    else
    {
        WriteLine($"Number {n} - no");
    }
}
// task 1
try
{
    DisplayMessage Message = message => WriteLine(message);

    string message;
    Message("Enter message that you want:");
    message = ReadLine();
    if (message == String.Empty) { message = "Null message!"; }
    Message("Your message: " + message);


    // task 2
    //    ArithmeticOperations math = new();
    //    MathOperations operations = math.Add;
    //    operations += math.Subs;
    //    operations += math.Divide;
    //    operations += math.Multiply;

    //    WriteLine("Enter number 1: ");
    //    math.Num1 = ValidateINT();
    //    WriteLine("Enter number 2: ");
    //    math.Num2 = ValidateINT();
    //    foreach (var op in operations.GetInvocationList())
    //    {
    //        WriteLine(op.DynamicInvoke());
    //    }
    //    WriteLine(math.ToString());

    Message("Is pair:");
    Analyze(2, CheckNumber.IsPair);
    Message("Is unpair:");
    Analyze(2, CheckNumber.IsUnpair);
    Message("Is simple:");
    Analyze(2, CheckNumber.IsSimple);
    Message("Is Fibonacci:");
    Analyze(2, CheckNumber.IsFibonacci);
}

catch(Exception ex)
{
    WriteLine(ex.Message);
}
