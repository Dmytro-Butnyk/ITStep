using BookShopDataBase.Models.BookDetails;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDataBase.Models.BookTable
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Part { get; set; }
        public Genre Genre {  get; set; }
        public Author Author { get; set; }
        public int Pages {  get; set; }
        public Publisher Publisher { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public decimal Price { get; set; }

        public Book() { }
        public Book(string name, int part, Genre genre, Author author, int pages, Publisher publisher, DateOnly releaseDate, decimal price)
        {
            Name = name;
            Part = part;
            Genre = genre;
            Author = author;
            Pages = pages;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            Price = price;
        }

        public override string ToString() =>
            $"Name: {Name}| Part: {Part}| Genre: {Genre}| " +
            $"Author: {Author}| Pages: {Pages}| Publisher: {Publisher}| " +
            $"Release date: {ReleaseDate}| Price: {Price}";
    }
}
