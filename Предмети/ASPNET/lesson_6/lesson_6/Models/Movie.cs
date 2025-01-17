using System.ComponentModel.DataAnnotations;

namespace lesson_6.Models;

public class Movie
{
    public uint Id { get; set; }
    public string Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
}
