using System.ComponentModel.DataAnnotations;

namespace hw_1.Models;

public class ProductType
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual List<Product> Products { get; set; }

    public ProductType(string name)
    {
        Name = name;
    }
    public ProductType(){}
}

