using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC_2.Models
{
    public class Book
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Display(Name = "Рік публікації")]
        public int ReleaseDate { get; set; }
        public int? AuthId { get; set; }
        [Required(ErrorMessage = "Publisher is required.")]
        public Publisher? Publisher { get; set; }

        [Range(2, 18, ErrorMessage = "Неприпустимий вік")]
        public int AgeCategory { get; set; }
        public Auth? Author { get; set; }
    }
   

}
