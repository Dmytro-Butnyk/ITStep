using System.Windows;
using hw_1.DataContext;

namespace hw_1;

public partial class ObjectsObservatorWindow : Window
{
    private readonly StockDataContext _context = new();
    
    public ObjectsObservatorWindow()
    {
        InitializeComponent();
        dgObjects.DisplayMemberPath = "Name";
    }

    public void ShowProducts(object sender, RoutedEventArgs e)
    {
        var products = _context.Products.ToList();
        if (products == null)
            MessageBox.Show("No products");
        dgObjects.ItemsSource = products;
    }

    public void ShowTypes(object sender, RoutedEventArgs e)
    {
        var types = _context.ProductTypes.ToList();
        if (types == null)
            MessageBox.Show("No types");
        dgObjects.ItemsSource = types;
    }

    public void ShowSuppliers(object sender, RoutedEventArgs e)
    {
        var suppliers = _context.Suppliers.ToList();
        if (suppliers == null)
            MessageBox.Show("No suppliers");
        dgObjects.ItemsSource = suppliers;
    }
}