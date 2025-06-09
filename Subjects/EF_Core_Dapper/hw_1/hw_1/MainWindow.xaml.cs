using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using hw_1.DataContext;
using hw_1.Models;

namespace hw_1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly StockDataContext _context = new();

    public MainWindow()
    {
        InitializeComponent();
        ProductType.ItemsSource = _context.ProductTypes.ToList();
        ProductType.DisplayMemberPath = "Name";
        ProductSupplier.ItemsSource = _context.Suppliers.ToList();
        ProductSupplier.DisplayMemberPath = "FL";
    }

    public void AddProduct(object sender, RoutedEventArgs e)
    {
        try
        {
            _context.Products.Add(new Product(ProductName.Text,
                ProductType.SelectedItem as ProductType,
                ProductSupplier.SelectedItem as Supplier));
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        ProductName.Clear();
        ProductType.SelectedIndex = 0;
        ProductSupplier.SelectedIndex = 0;
    }

    public void AddProductType(object sender, RoutedEventArgs e)
    {
        try
        {
            _context.ProductTypes.Add(new ProductType(ProductTypeName.Text));
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        LoadData();
        ProductTypeName.Clear();
    }

    public void AddSupplier(object sender, RoutedEventArgs e)
    {
        try
        {
            _context.Suppliers.Add(new Supplier(SupplierName.Text));
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        LoadData();
        SupplierName.Clear();
    }
    
    public void ShowObjectsObservator(object sender, RoutedEventArgs e)
    {
        var window = new ObjectsObservatorWindow();
        window.Show();
        Close();
    }

    private void LoadData()
    {
        ProductType.ItemsSource = _context.ProductTypes.ToList();
        ProductSupplier.ItemsSource = _context.Suppliers.ToList();
    }
}