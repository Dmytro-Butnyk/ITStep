using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Reflection;

namespace Server
{
    public class QuoteServer
    {
        private TcpListener server;
        private List<string> quotes;
        private List<TcpClient> clients;
        private const int MAX_CLIENTS = 3;

        public QuoteServer(string ip, int port)
        {
            server = new TcpListener(IPAddress.Parse(ip), port);
            quotes = new List<string>() { "Quote 1", "Quote 2", "Quote 3" };
            clients = new List<TcpClient>();
        }

        public async Task Start()
        {
            server.Start();
            WriteLine("Server runned...");
            WriteLine("Waiting for connection...");
            while (true)
            {

                TcpClient client = await server.AcceptTcpClientAsync();
                clients.Add(client);
                if (clients.Count > MAX_CLIENTS)
                {
                    client.GetStream().WriteAsync(Encoding.UTF8.GetBytes("Server overloaded. Try later"));
                    clients[3].Close();
                    clients.Remove(client);
                    continue;
                }
                string log = "";
                _ = HandleCLientAsync(client, log);
            }
        }
        private async Task HandleCLientAsync(TcpClient client, string log)
        {

            log += "Client connected: " + client.Client.RemoteEndPoint + ", Time: " + DateTime.Now;
            WriteLine("Client connected: " + client.Client.RemoteEndPoint + ", Time: " + DateTime.Now);

            NetworkStream stream = client.GetStream();

            while (client.Connected)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                log += $"\nRecieved request from {client.Client.RemoteEndPoint}: " + message;
                WriteLine($"Recieved request from {client.Client.RemoteEndPoint}: " + message);

                if (message == "Need quote")
                {
                    int index = new Random().Next(quotes.Count);
                    byte[] quote = Encoding.UTF8.GetBytes(quotes[index]);

                    await stream.WriteAsync(quote, 0, quote.Length);
                    log += "\nQuote sent: " + quotes[index];
                    WriteLine("Quote sent: " + quotes[index]);
                }
                else
                {
                    break;
                }
            }
            clients.Remove(client);
            log += "\nClient disconected: " + client.Client.RemoteEndPoint + ", Time: " + DateTime.Now;
            WriteLine("Client disconected: " + client.Client.RemoteEndPoint + ", Time: " + DateTime.Now);
            await File.AppendAllTextAsync("log.txt", log);
            client.Close();
        }
    }
}
