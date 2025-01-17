using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using lesson_4.Models;

namespace lesson_4.Pages
{
    public class SearchBooks : PageModel
    {
        public List<Book> Books { get; set; } = new List<Book>();

        [BindProperty] public string SearchBy { get; set; }

        [BindProperty] public string SearchQuery { get; set; }

        public void OnGet()
        {
            LoadBooks();
        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                switch (SearchBy)
                {
                    case "title":
                        Books = Books.Where(b => b.Title.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                        break;
                    case "year":
                        if (int.TryParse(SearchQuery, out int year))
                        {
                            Books = Books.Where(b => b.PublishDate.Year == year).ToList();
                        }
                        else
                        {
                            Books = new List<Book>(); 
                        }

                        break;
                    case "type":
                        if (Enum.TryParse(typeof(BookStyle), SearchQuery, true, out var type))
                        {
                            Books = Books.Where(b => b.Type == (BookStyle)type).ToList();
                        }
                        else
                        {
                            Books = new List<Book>(); 
                        }

                        break;
                }
            }
        }

        private void LoadBooks()
        {
            using var reader = new StreamReader("Books.json");
            Books = JsonSerializer.Deserialize<List<Book>>(reader.ReadToEnd());
        }
    }
}
    

  