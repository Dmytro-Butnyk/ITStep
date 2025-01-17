using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для TaskTwo.xaml
    /// </summary>
    public partial class TaskTwo : Window
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;

        public TaskTwo()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                _client = new TcpClient("127.0.0.1", 5000);
                NetworkStream stream = _client.GetStream();
                _reader = new StreamReader(stream, Encoding.UTF8);
                _writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string message = SearchTextBox.Text;
            await SendMessageToServer(message);

            string response = await _reader.ReadLineAsync();
            if (response.StartsWith("418"))
            {
                ResultsTextBlock.Text = response;
            }
            else
            {
                ResultsTextBlock.Text = response + Environment.NewLine;
                while (true)
                {
                    string text = await _reader.ReadLineAsync();
                    if (text == "<END>")
                    {
                        break;
                    }
                    ResultsTextBlock.Text += text + Environment.NewLine;
                }
            }
        }

        private async void ByeButton_Click(object sender, RoutedEventArgs e)
        {
            await SendMessageToServer("Bye");
            CloseConnection();
        }

        private async Task SendMessageToServer(string message)
        {
            if (_writer != null)
            {
                await _writer.WriteLineAsync(message);
            }
        }

        private void CloseConnection()
        {
            if (_client != null)
            {
                _client.Close();
                MessageBox.Show("Server response: See you later!");
                new MainWindow().Show();
                Close();
            }
        }
    }
}
