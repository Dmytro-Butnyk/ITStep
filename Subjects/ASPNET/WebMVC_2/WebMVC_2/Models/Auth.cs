using System.Collections.Generic;

namespace WebMVC_2.Models
{
    public class Auth
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        
        public ICollection<Book>? Books;
    }
}
