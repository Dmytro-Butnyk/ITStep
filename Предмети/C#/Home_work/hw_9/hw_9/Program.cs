// See https://aka.ms/new-console-template for more information
using hw_9;
using static System.Console;

try
{
    ArrayINT array = new ArrayINT(10);
    //task 1
    array.Show();
    array.Show("message!!");

    //task 2
    WriteLine($"Max: {array.Max()} Min: {array.Min()} Avg: {array.Avg()}");
    Write("Value to search: ");
    if (!int.TryParse(ReadLine(), out int num))
    {
        throw new Exception("TryParse(): Invalid value");
    }
    if (array.Search(num)) WriteLine("Found!");
    else WriteLine("Not found!");

    //task 3
    array.Show();
    array.SortAsc();
    array.Show();
    array.SortDesc();
    array.Show();
    array.SortByParam(true);
    array.Show();
    array.SortByParam(false);
    array.Show();

    //hw 1
    WriteLine($"Elements less then 10: {array.Less(10)}");
    WriteLine($"Elements greater then 10: {array.Greater(10)}");

    //hw 2
    array.ShowEven();
    array.ShowOdd();

    //hw 3
    WriteLine($"Count distinct: {array.CountDistinct()}");
    WriteLine($"Count values equal to 10: {array.EqualToValue(10)}");
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}