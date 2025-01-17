namespace lesson_4.Models;

public class Book
{
    public string Title { get; set; } = "NoTitle";
    public string AuthorName { get; set; } = "NoAuthor";
    public BookStyle Type { get; set; } = BookStyle.Romance;
    public DateOnly PublishDate { get; set; } = new();
    public decimal Price { get; set; } = 0;
    
    public Book (){}

    public Book(string title, string authorName, BookStyle type,
        DateOnly publishDate, decimal price)
    {
        Title = title;
        AuthorName = authorName;
        Type = type;
        PublishDate = publishDate;
        Price = price;
    }

    public override string ToString() =>
        $"Title: {Title} | Author: {AuthorName} | Publish date: {PublishDate} | Price: {Price}";
}

