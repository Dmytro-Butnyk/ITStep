using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Server
{
    static List<string> texts = new List<string>();

    static void Main(string[] args)
    {
        LoadTextsFromFiles("texts"); // Завантажуємо тексти з папки "texts"

        TcpListener server = new TcpListener(IPAddress.Any, 5000);
        server.Start();
        Console.WriteLine("Server started...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("User connected.");
            Task.Run(() => HandleClient(client));
        }
    }

    static void LoadTextsFromFiles(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            foreach (string filePath in Directory.GetFiles(directoryPath, "*.txt"))
            {
                texts.Add(File.ReadAllText(filePath));
            }
            Console.WriteLine($"Loaded {texts.Count} texts from {directoryPath}");
        }
        else
        {
            Console.WriteLine($"Directory {directoryPath} does not exist.");
        }
    }

    static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        try
        {
            while (true)
            {
                string message = reader.ReadLine();
                if (message == null)
                {
                    Console.WriteLine("User disconnected unexpectedly.");
                    break;
                }

                if (message == "Bye")
                {
                    Console.WriteLine("User disconnected.");
                    break;
                }

                string[] words = message.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                List<string> matchingTexts = texts
                    .Where(text => words.All(word =>
                        Regex.IsMatch(text, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
                    .ToList();

                if (matchingTexts.Count > 0)
                {
                    writer.WriteLine($"Found {matchingTexts.Count} texts.");
                    foreach (string text in matchingTexts)
                    {
                        writer.WriteLine(text);
                    }
                    writer.WriteLine("<END>"); // Позначаємо кінець відправлених текстів
                    Console.WriteLine($"Sent {matchingTexts.Count} texts to user.");
                }
                else
                {
                    writer.WriteLine("418 I'm a teapot");
                    Console.WriteLine("Sent '418 I'm a teapot' to user.");
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("User disconnected unexpectedly during communication.");
        }
        finally
        {
            client.Close();
            Console.WriteLine("Connection closed.");
        }
    }
}
