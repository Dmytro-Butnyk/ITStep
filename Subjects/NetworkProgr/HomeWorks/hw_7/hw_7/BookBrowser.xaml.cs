using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace hw_7
{
    /// <summary>
    /// Логика взаимодействия для BookBrowser.xaml
    /// </summary>
    public partial class BookBrowser : Window
    {
        // https://www.gutenberg.org/ebooks/search/?query=Hamlet+Wiliam&submit_search=Go%21
        private string _mainUrl = @"https://www.gutenberg.org/ebooks/search/?query=";
        private string _query = @"&submit_search=Go%21";
        public BookBrowser()
        {
            InitializeComponent();
        }

        public void Search_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery.Text))
            {
                return;
            }
            string query = string.Join("+", SearchQuery.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            MessageBox.Show(query);

            Browser.Source = new Uri(_mainUrl + query + _query);
        }
    }
}
