using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Client
{
    public class QuoteClient
    {
        private TcpClient client;

        public QuoteClient(string ip, int port)
        {
            client = new TcpClient(ip, port);
        }

        public async Task Connect()
        {
            NetworkStream stream = client.GetStream();

            while (true)
            {
                string message = await GetQuoteAsync();
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(buffer, 0, buffer.Length);
                if (message == "End")
                {
                    break;
                }

                byte[] data = new byte[1024];
                int bytes = await stream.ReadAsync(data, 0, data.Length);
                string quote = Encoding.UTF8.GetString(data, 0, bytes);
                if(quote == "Server overloaded. Try later")
                {
                    WriteLine("Server overloaded. Try later");
                    break;
                }
                WriteLine("Received quote: " + quote);

            }
            WriteLine("You disconnected!");
            client.Close();
        }

        private Task<string> GetQuoteAsync()
        {
            return Task.Run(() =>
            {
                while (true)
                {
                    WriteLine("Press\n" +
                        "1 - To request a quote;\n" +
                        "0 - Exit:");

                    switch (ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            {
                                return "Need quote";
                            }
                        case ConsoleKey.D0:
                            {
                                return "End";
                            }
                        default:
                            {
                                WriteLine("Wrong option!");
                                break;
                            }
                    }
                }
            });
        }
    }
}
