using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;

static void InitiateRandomValuesArr(out int[][] arr, int r, int c)
{
    arr = new int[r][];
    for(int i = 0; i < r; ++i)
    {
        arr[i] = new int[c];
    }
    Random rand = new Random();
    for(int i = 0; i < r; i++)
    {
        for(int j = 0; j < c; j++)
        {
            arr[i][j] = rand.Next(-20, 30);
        }
    }
}
static void ShowArray(int[][] arr)
{
    foreach (var r in arr)
    {
        foreach(var c in r)
        {
            Console.Write($"{c,4}");
        }
        Console.WriteLine();
    }
}
// task 2
static int SumBetweenMinMax(int[,] array, int minRow, int minCol, int maxRow, int maxCol)
{
    int sum = 0;
    int startRow = Math.Min(minRow, maxRow);
    int endRow = Math.Max(minRow, maxRow);
    int startCol = Math.Min(minCol, maxCol);
    int endCol = Math.Max(minCol, maxCol);

    int o;
    for (int i = startRow; i <= endRow; i++)
    {
        o = (i == endRow) ? endCol : array.GetLength(1) - 1;
        for (int j = (i == startRow) ? startCol : 0; j <= o; j++)
        {
            sum += array[i, j];
        }
    }

    return sum;
}
// task 3
static void AddMatrixs(int[][] arr1, int[][] arr2, out int[][] newArr)
{
    if (arr1.Length != arr2.Length || arr1[0].Length != arr2[0].Length)
    {
        throw new ArgumentException("Wrong size of matrix must be equal!");
    }
    newArr = new int[arr1.Length][];
    for(int i = 0; i < newArr.Length; ++i)
    {
        newArr[i] = new int[arr1[i].Length];
        for(int j = 0; j < newArr[i].Length; ++j)
        {
            newArr[i][j] = arr1[i][j] + arr2[i][j];
        }
    }
}
static void MultiplyMatrixWithNumber(int n, ref int[][] arr)
{
    for(int i = 0; i < arr.Length; i++)
    {
        for(int j = 0; j < arr[i].Length; j++)
        {
            arr[i][j] *= n;
        }
    }
}
static void MultiplyMatrices(int[][] arr1, int[][] arr2, out int[][] resultMatrix)
{
    int rowsA = arr1.Length;
    int colsA = arr1[0].Length;
    int rowsB = arr2.Length;
    int colsB = arr2[0].Length;

    if (colsA != rowsB)
    {
        throw new ArgumentException("Number of columns in Matrix A must be equal to number of rows in Matrix B.");
    }

    resultMatrix = new int[rowsA][];

    for (int i = 0; i < rowsA; i++)
    {
        resultMatrix[i] = new int[colsB];
        for (int j = 0; j < colsB; j++)
        {
            int sum = 0;
            for (int k = 0; k < colsA; k++)
            {
                sum += arr1[i][k] * arr2[k][j];
            }
            resultMatrix[i][j] = sum;
        }
    }
}
// task 4
static void FilterArray(ref int[] arr, int[] filter)
{
    if (arr == null || filter == null) return;
    if (arr.SequenceEqual(filter))
    {
        arr = new int[0];
        return;
    }

    int number = 0;
    foreach (var el in filter)
    {
        foreach (var it in arr)
        {
            if (el == it)
            {
                ++number;
                break;
            }
        }
    }
    if (number == 0) return;

    int[] new_arr = new int[arr.Length - number];
    int k = 0;
    for (int i = 0; i < arr.Length; ++i)
    {
        int cur = arr[i];
        bool isAdd = true;
        for (int j = 0; j < filter.Length; ++j)
        {
            if (cur == filter[j])
            {
                isAdd = false;
                break;
            }
        }
        if (isAdd)
        {
            new_arr[k] = cur;
            ++k;
        }
    }

    arr = new_arr;
}


// task 1
/*
    // Оголошення та заповнення одновимірного масиву А
    double[] A = new double[5];
    Console.WriteLine("Enter 5 numbers for array A:");
    for (int i = 0; i < A.Length; i++)
    {
        if (double.TryParse(Console.ReadLine(), out A[i]) == false)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            i--;
        }
    }

    // Оголошення та заповнення двовимірного масиву В випадковими числами
    double[,] B = new double[3, 4];
    Random random = new Random();
    Console.WriteLine("Array B (random numbers):");
    for (int i = 0; i < B.GetLength(0); i++)
    {
        for (int j = 0; j < B.GetLength(1); j++)
        {
            B[i, j] = random.NextDouble() * 10;
            Console.Write($"{B[i, j],8:F2} ");
        }
        Console.WriteLine();
    }

    // Знаходження максимального, мінімального елементів та суми усіх елементів в масивах
    double maxA = A[0];
    double minA = A[0];
    double sumA = 0;

    double maxB = B[0, 0];
    double minB = B[0, 0];
    double sumB = 0;

    for (int i = 0; i < A.Length; i++)
    {
        sumA += A[i];

        if (A[i] > maxA)
            maxA = A[i];

        if (A[i] < minA)
            minA = A[i];
    }

    for (int i = 0; i < B.GetLength(0); i++)
    {
        for (int j = 0; j < B.GetLength(1); j++)
        {
            sumB += B[i, j];

            if (B[i, j] > maxB)
                maxB = B[i, j];

            if (B[i, j] < minB)
                minB = B[i, j];
        }
    }

    // Виведення результатів
    Console.WriteLine("\nResults:");
    Console.WriteLine($"Array A: [{string.Join(", ", A)}]");
    Console.WriteLine($"Max element in A: {maxA}");
    Console.WriteLine($"Min element in A: {minA}");
    Console.WriteLine($"Sum of elements in A: {sumA}");

    Console.WriteLine($"\nArray B (random numbers):");
    for (int i = 0; i < B.GetLength(0); i++)
    {
        for (int j = 0; j < B.GetLength(1); j++)
        {
            Console.Write($"{B[i, j],8:F2} ");
        }
        Console.WriteLine();
    }

    Console.WriteLine($"Max element in B: {maxB,8:F2}");
    Console.WriteLine($"Min element in B: {minB,8:F2}");
    Console.WriteLine($"Sum of elements in B: {sumB,8:F2}");

    // Знаходження та виведення добутку елементів у кожному рядку масиву В
    Console.WriteLine("\nProduct of elements in each row of B:");
    for (int i = 0; i < B.GetLength(0); i++)
    {
        double rowProduct = 1;
        for (int j = 0; j < B.GetLength(1); j++)
        {
            rowProduct *= B[i, j];
        }
        Console.WriteLine($"Row {i + 1}: {rowProduct,8:F2}");
    }

    // Знаходження та виведення добутку елементів у кожному стовпчику масиву В
    Console.WriteLine("\nProduct of elements in each column of B:");
    for (int j = 0; j < B.GetLength(1); j++)
    {
        double colProduct = 1;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            colProduct *= B[i, j];
        }
        Console.WriteLine($"Column {j + 1}: {colProduct,8:F2}");
    }

    // Знаходження та виведення суми парних елементів масиву А
    double sumEvenA = 0;
    for (int i = 0; i < A.Length; i++)
    {
        if (i % 2 == 0)
            sumEvenA += A[i];
    }
    Console.WriteLine($"\nSum of even elements in A: {sumEvenA}");

    // Знаходження та виведення суми непарних стовпців масиву В
    double sumOddColumnsB = 0;
    for (int j = 0; j < B.GetLength(1); j++)
    {
        if (j % 2 != 0)
        {
            for (int i = 0; i < B.GetLength(0); i++)
            {
                sumOddColumnsB += B[i, j];
            }
        }
    }
    Console.WriteLine($"Sum of elements in odd columns of B: {sumOddColumnsB,8:F2}");
*/
// task 2
/*
int size = 5;
int j;
int[,] B = new int[size, size];
Random random = new Random();
Console.WriteLine("Array B (random numbers):");
for (int i = 0; i < B.GetLength(0); i++)
{
    for (j = 0; j < B.GetLength(1); j++)
    {
        B[i, j] = random.Next(-100, 100);
        Console.Write($"{B[i, j]} ");
    }
    Console.WriteLine();
}
int i_1 = 0, j_1 = 0, min = B[0, 0];
int i_2 = 0, j_2 = 0, max = B[0, 0];
for(int i = 0; i < size; i++)
{
    for(j = 0; j < size; j++)
    {
        if(min > B[i, j])
        {
            min = B[i, j];
            i_1 = i;
            j_1 = j;
        }
        if(max < B[i, j])
        {
            max = B[i, j];
            i_2 = i;
            j_2 = j;
        }
    }
}
int res = SumBetweenMinMax(B, i_1, j_1, i_2, j_2);;
Console.WriteLine($"Sum between {min}({i_1},{j_1}) and {max}({i_2}, {j_2}) is: {res}");
*/
// task 3
/*
int[][] arr1, arr2, arr3;
InitiateRandomValuesArr(out arr1, 3, 3);
InitiateRandomValuesArr(out arr2, 3, 3);
Console.WriteLine("Matrix 1:");
ShowArray(arr1);
Console.WriteLine("\nMatrix 2:");
ShowArray(arr2);

MultiplyMatrices(arr1 , arr2, out arr3);
Console.WriteLine("\nMatrix 3:");
ShowArray(arr3);
*/
//task 4
Random rnd = new Random();
int[] arr = new int[5], filter = new int[3];
for(int i = 0; i < arr.Length; ++i)
{
    arr[i] = rnd.Next(1, 10);
}
for(int i = 0; i < filter.Length; ++i)
{
    filter[i] = rnd.Next(1, 10);
}

FilterArray(ref arr, filter);
foreach(var it in arr)
{
    Console.Write($"{it,3}");
}