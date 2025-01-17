// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
string host = "127.0.0.1";
int port = 8888;
using TcpClient client = new TcpClient();
Console.Write("Введіть своє ім'я: ");
string? userName = Console.ReadLine();
Console.WriteLine($"Ласкаво просимо, {userName}");
StreamReader? Reader = null;
StreamWriter? Writer = null;

try
{
    client.Connect(host, port); //підключення клієнта
    Reader = new StreamReader(client.GetStream());
    Writer = new StreamWriter(client.GetStream());
    if (Writer is null || Reader is null) return;
    // запускаємо новий потік для отримання даних
    Task.Run(() => ReceiveMessageAsync(Reader));
    // запускаємо введення повідомлень
    await SendMessageAsync(Writer);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Writer?.Close();
Reader?.Close();

// надсилання повідомлень
async Task SendMessageAsync(StreamWriter writer)
{
    // спочатку відправляємо ім'я
    await writer.WriteLineAsync(userName);
    await writer.FlushAsync();
    Console.WriteLine("Щоб надіслати повідомлення, введіть повідомлення та натисніть Enter");

    while (true)
    {
        string? message = Console.ReadLine();
        await writer.WriteLineAsync(message);
        await writer.FlushAsync();
    }
}
// отримання повідомлень
async Task ReceiveMessageAsync(StreamReader reader)
{
    while (true)
    {
        try
        {
            // зчитуємо відповідь у вигляді рядка
            string? message = await reader.ReadLineAsync();
            // якщо порожня відповідь, нічого не виводимо на консоль
            if (string.IsNullOrEmpty(message)) continue;
            Print(message);//вывод сообщения
        }
        catch
        {
            break;
        }
    }
}
// щоб отримане повідомлення не накладалося на введення нового повідомлення
void Print(string message)
{
    if (OperatingSystem.IsWindows())    // якщо ОС Windows
    {
        var position = Console.GetCursorPosition(); // отримуємо поточну позицію курсору
        int left = position.Left; // Зміщення у символах щодо лівого краю
        int top = position.Top; // Зміщення у рядках щодо верху
        // копіюємо раніше введені символи у рядку на наступний рядок
        Console.MoveBufferArea(0, top, left, 1, 0, top + 1);
        // встановлюємо курсор на початок поточного рядка
        Console.SetCursorPosition(0, top);
        // у поточному рядку виводить отримане повідомлення
        Console.WriteLine(message);
        // Переносимо курсор на наступний рядок
        // та користувач продовжує введення вже на наступному рядку
        Console.SetCursorPosition(left, top + 1);
    }
    else Console.WriteLine(message);
}
