using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Console;

const string endMessage = "END";

IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
int port = 1488;

TcpClient tcpClient = new();


try
{
    await tcpClient.ConnectAsync(iPAddress, port);
    using (var stream = tcpClient.GetStream())
    {
        WriteLine("--You are connected--");
        while (true)
        {
            string request = await GetRequestAsync();
            byte[] buffer = Encoding.UTF8.GetBytes(request);
            await stream.WriteAsync(buffer, 0, buffer.Length);
            if (request == endMessage)
                break;

            buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string info = Encoding.UTF8.GetString(buffer);

            WriteLine($"|Founded information: {info}|");
        }
        WriteLine("You are disconnected!");
        tcpClient.Close();
    }
}
catch(Exception ex)
{
    WriteLine("Error: " + ex.Message);
}
async Task<string> GetRequestAsync()
{
    while (true)
    {
        WriteLine("|Press 1 - to enter request, 0 - exit|");
        switch (ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                {
                    Write("Enter your request: ");
                    return ReadLine();
                }
            case ConsoleKey.D0:
                {
                    return endMessage;
                }
            default:
                {
                    WriteLine("Wrong option!");
                    break;
                }
        }
    }
}
