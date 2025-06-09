using hw_last.TaskWindows;
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

namespace hw_last
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (BrowserMode.IsChecked == true)
            {
                Window window = new TaskOne();
                window.Show();
                Close();
            }
            if (ServerMode.IsChecked == true)
            {
                Window window = new TaskTwo();
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Choose one of the options!");
            }
        }
    }
}