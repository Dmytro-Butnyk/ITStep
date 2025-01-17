using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Console;

WriteLine();
try
{
    IPEndPoint IPPoint = new(IPAddress.Parse("127.0.0.1"), 1488);
    var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    await client.ConnectAsync(IPPoint);

    while (true)
    {
        string category = GetQuote();
        
        byte[] request = Encoding.UTF8.GetBytes(category);
        await client.SendAsync(request, 0);
        if(category == "<END>")
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            break;
        }
        byte[] response = new byte[1024];
        int bytesRead = await client.ReceiveAsync(response, 0);
        string quote = Encoding.UTF8.GetString(response, 0, bytesRead);
        WriteLine($"Quote: {quote}");
    }
}
catch(Exception ex)
{
    WriteLine(ex.Message);
}

static string GetQuote()
{
A:

    WriteLine("Press\n" +
        "1 - Self-Improvement;\n" +
        "2 - Friendship;\n" +
        "3 - Courage;\n" +
        "0 - <END>:");

    switch (ReadKey(true).Key)
    {
        case ConsoleKey.D1:
            {
                return "Self-Improvement";
            }
        case ConsoleKey.D2:
            {
                return "Friendship";
            }
        case ConsoleKey.D3:
            {
                return "Courage";
            }
        case ConsoleKey.D0:
            {
                return "<END>";
            }
        default:
            {
                WriteLine("Wrong option!");
                goto A;
            }
    }
}