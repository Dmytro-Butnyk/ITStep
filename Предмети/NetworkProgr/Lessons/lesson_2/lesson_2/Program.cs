using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        IPEndPoint IPPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1488);
        var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        listener.Bind(IPPoint);
        listener.Listen(10);
        while (true)
        {
            var client = listener.Accept();

            _ = HandleClientAsync(client);
        }
    }

    static async Task HandleClientAsync(Socket client)
    {
        while (true)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = await client.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
            string category = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            string clientIP = ((IPEndPoint)client.RemoteEndPoint).Address.ToString();
            Console.WriteLine($"Client {clientIP} sent request: {category}");
            if (category == "<END>")
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                break;
            }
            string quote = GetQuote(category);
            byte[] response = Encoding.UTF8.GetBytes(quote);
            await client.SendAsync(new ArraySegment<byte>(response), SocketFlags.None);

        }
    }

    static string GetQuote(string category)
    {
        switch (category)
        {
            case "Self-Improvement":
                return @"“Always strive to be better than you were yesterday. That’s the surest path to success.”";
            case "Friendship":
                return @"“Friends are the family we choose for ourselves. Cherish them.”";
            case "Courage":
                return @"“Courage is not the absence of fear, but rather the judgement that something else is more important than fear.”";
            default:
                return null;
        }
    }
}
