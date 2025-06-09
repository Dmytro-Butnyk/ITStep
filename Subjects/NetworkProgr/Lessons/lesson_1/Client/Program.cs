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
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);

            string message = "";
            while (message != "End")
            {
                Console.WriteLine("Enter message:");
                message = Console.ReadLine();
                byte[] data = Encoding.Default.GetBytes(message);
                socket.Send(data);

                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                data = new byte[256];

                do
                {
                    bytes = socket.Receive(data);
                    builder.Append(Encoding.Default.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);

                Console.WriteLine("Server's response: " + builder.ToString());
                if (builder.ToString() == "End")
                {
                    break;
                }
            }

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
