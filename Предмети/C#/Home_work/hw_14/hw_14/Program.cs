using hw_14;


// task 1

Play play = new Play("Hamlet","William Shakespeare", "Tragedy", 1603);
Console.WriteLine(play.Title);
play.Dispose();

// task 2

Store store = new("Grocery Store", "123 Main St", "Grocery");
Console.WriteLine(store.Name);
store.Dispose();
