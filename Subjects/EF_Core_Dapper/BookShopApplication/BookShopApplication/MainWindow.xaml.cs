using BookShopDataBase;
using BookShopDataBase.Models.ClientDetails;
using System.Windows;

namespace BookShopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DB_BookShop _context = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void Autorization_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login_Enter.Text) || string.IsNullOrWhiteSpace(Password_Enter.Text))
                return;

            if (_context.Clients.Any(x => x.Login == Login_Enter.Text && x.Password == Password_Enter.Text))
            {
                Client authedUser = _context.Clients.FirstOrDefault(x => x.Login == Login_Enter.Text && x.Password == Password_Enter.Text);

            }
            else if (Login_Enter.Text == "Admin" && Password_Enter.Text == "Admin")
            {
                new ManagerWindow_1().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Wrong login or password!\n" +
                    "Try again");
            }
        }
        public async void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login_Enter.Text) || string.IsNullOrWhiteSpace(Password_Enter.Text))
                return;
            if (Login_Enter.Text == "Admin" && Password_Enter.Text == "Admin")
            {
                MessageBox.Show("You can not register Admin!");
                return;
            }
            if (!_context.Clients.Any(x => x.Login == Login_Enter.Text && x.Password == Password_Enter.Text))
            {
                _context.Add(new Client(Login_Enter.Text, Password_Enter.Text));
                _context.SaveChanges();
                MessageBox.Show("User added!\n" +
                    "You can use \"Log In\" button");
            }
            else
                MessageBox.Show("User exists!\n" +
                    "You can use \"Log In\" button");
        }
    }
}