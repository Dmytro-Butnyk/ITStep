using System.Text.Json;
using lesson_4.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lesson_4.Pages;

public class BookList : PageModel
{
    public List<Book> Books { get; set; } = new List<Book>();
    
    public void OnGet()
    {
        for (int i = 0; i < 5; i++)
        {
            using var reader = System.IO.File.OpenRead("Books.json");
            Books = JsonSerializer.Deserialize<List<Book>>(reader);
        }
    }
}