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

namespace hw_last.TaskWindows
{
    /// <summary>
    /// Логика взаимодействия для TaskOne.xaml
    /// </summary>
    public partial class TaskOne : Window
    {
        private string _browserUrl = @"https://www.bing.com/search?q=";
        public TaskOne()
        {
            InitializeComponent();
        }

        public void SearchButton_Click (object sentder, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchRequest.Text))
                return;

            Browser.Navigate(_browserUrl + SearchRequest.Text.Replace(' ', '+'));
        }
    }
}
