
using hw_12;

// task 1
BookList bookList = new BookList();

Book book1 = new Book
(
    "Война и мир",
    "Лев Толстой",
    "Роман",
    1869
);

Book book2 = new Book
(
    "Преступление и наказание",
    "Федор Достоевский",
    "Роман",
    1866
);

bookList.AddBook(book1);
bookList.AddBook(book2);

bookList.RemoveFirstBook();


// task 3
ClinicQueue clinicQueue = new ClinicQueue();

clinicQueue.Arrive(new Patient { Name = "Dima", Priority = 2 });
clinicQueue.Arrive(new Patient { Name = "Ilya", Priority = 1 });

Patient nextPatient = clinicQueue.NextPatient();
Console.WriteLine(nextPatient.Name);
    
