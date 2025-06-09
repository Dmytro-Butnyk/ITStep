using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        string address = "192.168.247.68";
        int port = 1488;

        try
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                serverSocket.Bind(ipPoint);
                serverSocket.Listen(10);

                Console.WriteLine("Waiting for connection...");

                while (true)
                {
                    using (Socket clientSocket = serverSocket.Accept())
                    {
                        HandleClient(clientSocket);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void HandleClient(Socket clientSocket)
    {
        string clientIP = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();
        Console.WriteLine($"Client connected: {clientIP}");

        while (true)
        {
            StringBuilder builder = new StringBuilder();
            byte[] data = new byte[1024];
            int bytes = 0;

            do
            {
                bytes = clientSocket.Receive(data);
                builder.Append(Encoding.Default.GetString(data, 0, bytes));
            } while (clientSocket.Available > 0);

            string message = builder.ToString();
            Console.WriteLine($"Received message: {message}");

            if (message == "End")
            {
                break;
            }

            Console.WriteLine("Enter message: ");
            message = Console.ReadLine();
            data = Encoding.Default.GetBytes(message);
            clientSocket.Send(data);
        }
    }
}
