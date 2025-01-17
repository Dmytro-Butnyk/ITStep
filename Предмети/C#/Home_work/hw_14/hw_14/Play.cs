using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_14
{
    public class Play : IDisposable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Play(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public void DisplayPlayInfo()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {Year}");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose method is called.");
        }

        ~Play()
        {
            Console.WriteLine("Destructor is called.");
        }
    }

}
