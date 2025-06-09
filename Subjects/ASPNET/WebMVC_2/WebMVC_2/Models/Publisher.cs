namespace WebMVC_2.Models;

public class Publisher(string name)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;
}