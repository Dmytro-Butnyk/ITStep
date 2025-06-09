using hw_10;
using static hw_10.Task1;

// task 1

//int[] numbers = Enumerable.Range(1, 100).ToArray();

//DisplayNumbers(numbers, IsEven);
//DisplayNumbers(numbers, IsOdd);
//DisplayNumbers(numbers, IsPrime);
//DisplayNumbers(numbers, IsFibonacci);

// task 2

//Action displayTime = () => Console.WriteLine(DateTime.Now.TimeOfDay);
//Action displayDate = () => Console.WriteLine(DateTime.Now.Date);
//Action displayDayOfWeek = () => Console.WriteLine(DateTime.Now.DayOfWeek);
//Func<double, double, double> calculateTriangleArea = (baseLength, height) => 0.5 * baseLength * height;
//Func<double, double, double> calculateRectangleArea = (length, width) => length * width;

//displayTime();
//displayDate();
//displayDayOfWeek();
//Console.WriteLine(calculateTriangleArea(3, 4));
//Console.WriteLine(calculateRectangleArea(3, 4));

// task 3

//string text = "Hello, world!";
//string word = "world";

//Func<string, bool> containsWord = t => t.Contains(word);

//Console.WriteLine(containsWord(text));

// task 4

//int[] numbers = Enumerable.Range(1, 100).ToArray();

//Func<int[], int> countMultiplesOfSeven = nums => nums.Count(n => n % 7 == 0);

//Console.WriteLine(countMultiplesOfSeven(numbers));

// task 5

//int[] numbers = { -3, -2, -1, 0, 1, 2, 3 };

//Func<int[], int> countPositiveNumbers = nums => nums.Count(n => n > 0);

//Console.WriteLine(countPositiveNumbers(numbers));

// task 6

//int[] numbers = { -3, -2, -2, -1, 0, 1, 2, 3 };

//Action<int[]> uniqueNegativeNumbers = nums =>
//{
//    foreach (int number in nums.Distinct().Where(n => n < 0))
//    {
//        Console.WriteLine(number);
//    }
//};

//uniqueNegativeNumbers(numbers);

// task 7

//string validString = "{}[]";
//string invalidString = "[}";

//Console.WriteLine(validString.IsValidBrackets());
//Console.WriteLine(invalidString.IsValidBrackets());

// task 8

int[] numbers = Enumerable.Range(1, 100).ToArray();


int[] evenNumbers = numbers.Filter();

foreach (int number in evenNumbers)
{
    Console.WriteLine(number);
}




