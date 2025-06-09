static void Main(string[] args)
    {

    // task 2

    //int num1 = int.Parse(args[0]);
    //int num2 = int.Parse(args[1]);
    //string operation = args[2];

    //switch (operation)
    //{
    //    case "+":
    //        {
    //            Console.WriteLine(num1 + num2);
    //            break;
    //        }
    //}

    // task 3
        string filePath = args[0];
        string wordToFind = args[1];

        string text = File.ReadAllText(filePath);
        int wordCount = text.Split(new[] { wordToFind }, StringSplitOptions.None).Length - 1;

        Console.WriteLine($"The word '{wordToFind}' apeared {wordCount} times.");
}
