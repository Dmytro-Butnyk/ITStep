using static System.Console;


/*
// task 1
async Task<int> CountUniqueValues(string filePath)
{
    var numbers = (await File.ReadAllLinesAsync(filePath)).Select(int.Parse);
    var uniqueNumbers = numbers
.AsParallel()
.Distinct()
.Count();
    return uniqueNumbers;
}


// task 2
async Task<int> MaxIncreasingSequenceLength(string filePath)
{
    var numbers = (await File.ReadAllLinesAsync(filePath)).Select(int.Parse).ToList();
    return numbers
.AsParallel()
.Select((n, i) => numbers.Skip(i).TakeWhile((m, index) => index == 0 || numbers[i + index - 1] < numbers[i + index]).Count())
.Max();
}


// task 3
async Task<int> MaxPositiveSequenceLength(string filePath)
{
    var numbers = (await File.ReadAllLinesAsync(filePath)).Select(int.Parse).ToList();
    return numbers.AsParallel().Select((n, i) => numbers.Skip(i).TakeWhile(m => m > 0).Count()).Max();
}


*/



