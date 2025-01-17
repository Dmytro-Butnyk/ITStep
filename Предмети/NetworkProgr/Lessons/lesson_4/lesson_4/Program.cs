using lesson_4;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Console;
using System.Collections.Concurrent;

ConcurrentDictionary<string, PCComponent> pCComponents = new()
{
    ["GPU"] = new PCComponent("GPU", 18000),
    ["CPU"] = new PCComponent("CPU", 9000),
    ["RAM"] = new PCComponent("RAM", 4000),
    ["HDD"] = new PCComponent("HDD", 1500),
    ["SSD"] = new PCComponent("SSD", 3000)
};
IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
int port = 1488;

TcpListener listener = new TcpListener(iPAddress, port);
listener.Start();
WriteLine("--Server started--");
await File.AppendAllTextAsync("Logs.txt", $"SERVER STARTED, TIME: {DateTime.Now}");

while (true)
{
    TcpClient client = await listener.AcceptTcpClientAsync();
    _ = HandleClientAsync(client);
}

async Task HandleClientAsync(TcpClient client)
{
    StringBuilder log = new StringBuilder($"Client connected: {client.Client.RemoteEndPoint}, Time: {DateTime.Now}\n");
    WriteLine($"Client connected: {client.Client.RemoteEndPoint}, Time: {DateTime.Now}");

    using (var stream = client.GetStream())
    {
        while (true)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            log.AppendLine($"Received request: {request}");
            WriteLine($"Received request: {request}");

            if (request != "END")
                await stream.WriteAsync(Encoding.UTF8.GetBytes(HandleRequest(pCComponents, request)));
            else
                break;
        }
        log.AppendLine($"Client disconnected {client.Client.RemoteEndPoint}, Time: {DateTime.Now}");
        await File.AppendAllTextAsync("Logs.txt", log.ToString());
        client.Close();
    }
}

string HandleRequest(ConcurrentDictionary<string, PCComponent> pCs, string request) 
{
    if (pCs.TryGetValue(request, out var component))
        return component.ToString();
    else
        return "No components for your request";
}
