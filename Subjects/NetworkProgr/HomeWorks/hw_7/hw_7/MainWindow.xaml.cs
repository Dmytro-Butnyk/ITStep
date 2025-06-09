using System.Diagnostics.Eventing.Reader;
using System.Net;
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

namespace hw_7
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
        private async void NextWindow(object sender, RoutedEventArgs e)
        {
            Window window = new TaskTwo();
            window.Show();
            this.Close();
        }
        private async void LoadText(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gamletText.Text == null || gamletText.Text == "")
                {
                    string url = "https://www.gutenberg.org/cache/epub/1787/pg1787.txt";

                    using (WebClient client = new WebClient())
                    {
                        string downloadedText = await client.DownloadStringTaskAsync(url);

                        gamletText.Text = downloadedText;
                    }
                }
                else
                    gamletText.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні тексту: " + ex.Message);
            }
        }
    }
}