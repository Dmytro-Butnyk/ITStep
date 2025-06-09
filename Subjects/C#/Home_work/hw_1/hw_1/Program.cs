using System.Numerics;

namespace hw_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // task 1
            /*
                A:
                try
                {
                    int n;
                    Console.WriteLine("Enter number 1 - 100:");
                    n = int.Parse(Console.ReadLine());
                    if (n < 1 || n > 100)
                    {
                        Console.WriteLine("Number must be between 1 and 100.");
                        goto A;
                    }
                    else
                    {
                        if (n % 3 == 0 && n % 5 == 0)
                        {
                            Console.WriteLine("Fizz Buzz");
                        }
                        else if (n % 5 == 0)
                        {
                            Console.WriteLine("Buzz");
                        }
                        else if (n % 3 == 0)
                        {
                            Console.WriteLine("Fizz");
                        }
                        else
                        {
                            Console.WriteLine(n);
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Try again.");
                    goto A;
                }
           */
            // task 2
            /*
            double val, interest;
            Console.WriteLine("Enter value:");
            if(double.TryParse(Console.ReadLine(), out val))
            {
                Console.WriteLine($"Your value: {val}");
            }
            Console.WriteLine("Enter interest of value:");
            if(double.TryParse(Console.ReadLine(), out interest))
            {
                Console.WriteLine($"The interest is: {interest}");
            }
            Console.WriteLine($"Result: {interest}% from {val} = {val * (interest / 100)}");
            */
            // task 3
            /*
            int size = 4;
            int x, result = 0;
            int it = (int)Math.Pow(10, size);
            Console.WriteLine($"Enter {size} numbers:");
            for (int i = 0; i < size; i++)
            {
                A:
                Console.Write($"Number {i + 1}: ");
                if(int.TryParse( Console.ReadLine(), out x) && x < 10 && x >= 0)
                {
                    result += x * (it /= 10); 
                }
                else
                {
                    Console.WriteLine("Wrong number!");
                    goto A;
                }
            }
            Console.WriteLine($"Your number: {result}");
            */
            // task 4
            /*
            int result;
            Console.WriteLine("Enter a six-digit number:");
            string inputNumber = Console.ReadLine();

            if (inputNumber.Length == 6 && int.TryParse(inputNumber, out int originalNumber))
            {
                Console.WriteLine("Enter positions of digits to swap (for example: 1 6):");
                string[] positions = Console.ReadLine().Split(' ');

                if (positions.Length == 2 && int.TryParse(positions[0], out int position1) && int.TryParse(positions[1], out int position2))
                {
                    if (position1 >= 1 && position1 <= 6 && position2 >= 1 && position2 <= 6)
                    {
                        result = SwapDigits(originalNumber, position1, position2);
                        Console.WriteLine($"Result: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid digit positions. Enter numbers from 1 to 6.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect format for entered digit positions.");
                }
            }
            else
            {
                Console.WriteLine("Error: Enter a six-digit number.");
            }
            */
            // task 5
            /*
            Console.WriteLine("Enter a date (format: dd.mm.yyyy):");
            string inputDate = Console.ReadLine();

            if (DateTime.TryParseExact(inputDate, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                string season = GetSeason(date.Month);
                string dayOfWeek = date.DayOfWeek.ToString();

                Console.WriteLine($"{season} {dayOfWeek}");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date (dd.mm.yyyy).");
            }
            */
            // task 6
            /*
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Convert Fahrenheit to Celsius");
            Console.WriteLine("2. Convert Celsius to Fahrenheit");

            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
            {
                Console.WriteLine("Enter the temperature:");

                if (double.TryParse(Console.ReadLine(), out double temperature))
                {
                    double convertedTemperature = (choice == 1) ? FahrenheitToCelsius(temperature) : CelsiusToFahrenheit(temperature);

                    string fromUnit = (choice == 1) ? "Fahrenheit" : "Celsius";
                    string toUnit = (choice == 1) ? "Celsius" : "Fahrenheit";

                    Console.WriteLine($"{temperature} {fromUnit} is {convertedTemperature.ToString("F2")} {toUnit}.");
                }
                else
                {
                    Console.WriteLine("Invalid temperature input. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose 1 or 2.");
            }
            */
            // task 7
            int start, end;
            Console.WriteLine("Enter start and end of the range:");
            if(int.TryParse(Console.ReadLine(), out start) && int.TryParse(Console.ReadLine(), out end))
            {
                if(start > end)
                {
                    Swap(ref start, ref end);
                }
                Console.WriteLine("Paired numbers in your range:");
                for(int i = start+1; i < end; i++)
                {
                    if(i % 2 == 0)
                    {
                        Console.Write(" " + i);
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong values!");
            }
        }
        static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
        static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }
        static string GetSeason(int month)
    {
        switch (month)
        {
            case 12:
            case 1:
            case 2:
                return "Winter";
            case 3:
            case 4:
            case 5:
                return "Spring";
            case 6:
            case 7:
            case 8:
                return "Summer";
            case 9:
            case 10:
            case 11:
                return "Autumn";
            default:
                return "Invalid Month";
        }
    }
        static int SwapDigits(int number, int position1, int position2)
        {
            char[] digits = number.ToString().ToCharArray();

            position1--;
            position2--;

            char temp = digits[position1];
            digits[position1] = digits[position2];
            digits[position2] = temp;

            return int.Parse(digits);
        }
    }
}
