using System.ComponentModel.DataAnnotations;

namespace hw_1.Models;

public class Product
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    public ProductType? Type { get; set; }
    public Supplier Supplier { get; set; }

    public Product(string name, ProductType? type, Supplier supplier)
    {
        Name = name;
        Type = type;
        Supplier = supplier;
    }

    public Product()
    {
    }
}