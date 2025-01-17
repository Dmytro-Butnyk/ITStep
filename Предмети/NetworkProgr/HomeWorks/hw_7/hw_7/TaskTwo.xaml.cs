using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для TaskTwo.xaml
    /// </summary>
    public partial class TaskTwo : Window
    {
        private string _mainPageUrl = "https://www.gutenberg.org";
        private Dictionary<string, string> _books;
        public TaskTwo()
        {
            InitializeComponent();
        }

        public void LoadTop_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient webClient = new())
            {
                string url = @"https://www.gutenberg.org/browse/scores/top";
                Regex bookPageURLregex = new(@"^\/ebooks\/\d+$");
                string htmlString = webClient.DownloadString(url);

                _books = ParseBooks(htmlString, 100);

                Top100BooksList.ItemsSource = _books.Keys;
            }
        }
        public void LoadBookPage_Click(object sender, RoutedEventArgs e)
        {
            Browser.Source = new Uri(_mainPageUrl + _books[Top100BooksList.SelectedItem.ToString()]);
        }
        private Dictionary<string, string> ParseBooks(string html, int limit)
        {
            Dictionary<string, string> books = new Dictionary<string, string>();

            Regex bookRegex = new Regex(@"<li><a href=""/ebooks/(\d+)"">(.*?) by .*? \((\d+)\)</a></li>");

            MatchCollection bookMatches = bookRegex.Matches(html);

            int count = Math.Min(bookMatches.Count, limit);

            for (int i = 0; i < count; i++)
            {
                string url = "/ebooks/" + bookMatches[i].Groups[1].Value;
                string title = bookMatches[i].Groups[2].Value;

                books[title] = url;
            }

            return books;
        }

        private void LoadNextPage_Click(object sender, RoutedEventArgs e)
        {
            Window window = new BookBrowser();
            window.Show();
            Close();
        }
    }
}
