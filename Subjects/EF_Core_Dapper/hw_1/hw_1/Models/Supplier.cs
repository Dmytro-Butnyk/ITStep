namespace hw_1.Models;

public class Supplier
{
    public int Id { get; set; }
    public string FL { get; set; }
    public virtual List<Product> Products { get; set; }
    
    public Supplier(string fl)
    {
        FL = fl;
    }
    public Supplier(){}
}