// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
ServerObject server = new ServerObject();// створюємо сервер
await server.ListenAsync(); // запускаємо сервер

class ServerObject
{
    TcpListener tcpListener = new TcpListener(IPAddress.Any, 8888); // сервер для прослуховування
    List<ClientObject> clients = new List<ClientObject>(); // всі підключення
    protected internal void RemoveConnection(string id)
    {
        // отримуємо по id закрите підключення
        ClientObject? client = clients.FirstOrDefault(c => c.Id == id);
        // та видаляємо його зі списку підключень
        if (client != null) clients.Remove(client);
        client?.Close();
    }
    // прослуховування вхідних підключень
    protected internal async Task ListenAsync()
    {
        try
        {
            tcpListener.Start();
            Console.WriteLine("Сервер запущено. Очікування підключень...");

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();

                ClientObject clientObject = new ClientObject(tcpClient, this);
                clients.Add(clientObject);
                Task.Run(clientObject.ProcessAsync);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Disconnect();
        }
    }

    // трансляція повідомлення підключеним клієнтам
    protected internal async Task BroadcastMessageAsync(string message, string id)
    {
        foreach (var client in clients)
        {
            if (client.Id != id) // якщо id клієнта не дорівнює id відправника
            {
                await client.Writer.WriteLineAsync(message); //передача даних
                await client.Writer.FlushAsync();
            }
        }
    }
    // відключення всіх клієнтів
    protected internal void Disconnect()
    {
        foreach (var client in clients)
        {
            client.Close(); //відключення клієнта
        }
        tcpListener.Stop(); //зупинка сервера
    }
}
class ClientObject
{
    protected internal string Id { get; } = Guid.NewGuid().ToString();
    protected internal StreamWriter Writer { get; }
    protected internal StreamReader Reader { get; }

    TcpClient client;
    ServerObject server; // об'єкт сервера

    public ClientObject(TcpClient tcpClient, ServerObject serverObject)
    {
        client = tcpClient;
        server = serverObject;
        // отримуємо NetworkStream для взаємодії із сервером
        var stream = client.GetStream();
        // створюємо StreamReader для читання даних
        Reader = new StreamReader(stream);
        // створюємо StreamWriter для надсилання даних
        Writer = new StreamWriter(stream);
    }

    public async Task ProcessAsync()
    {
        try
        {
            // отримуємо ім'я користувача
            string? userName = await Reader.ReadLineAsync();
            string? message = $"{userName} зайшов ";
            // надсилаємо повідомлення про вхід у чат всім підключеним користувачам
            await server.BroadcastMessageAsync(message, Id);
            Console.WriteLine(message);
            // у нескінченному циклі отримуємо повідомлення від клієнта
            while (true)
            {
                try
                {
                    message = await Reader.ReadLineAsync();
                    if (message == null) continue;
                    message = $"{userName}: {message}";
                    Console.WriteLine(message);
                    await server.BroadcastMessageAsync(message, Id);
                }
                catch
                {
                    message = $"{userName} покинув чат";
                    Console.WriteLine(message);
                    await server.BroadcastMessageAsync(message, Id);
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            // у разі виходу з циклу закриваємо ресурси
            server.RemoveConnection(Id);
        }
    }
    // закриття підключення

    protected internal void Close()
    {
        Writer.Close();
        Reader.Close();
        client.Close();
    }
}