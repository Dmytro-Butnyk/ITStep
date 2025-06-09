using hw_5;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Console;

IPAddress iPAddress = IPAddress.Parse("127.0.0.1");

Write("Enter local port: ");
_ = int.TryParse(ReadLine(), out var localPort);

Write("Enter remote port: ");
_ = int.TryParse(ReadLine(), out var remotePort);

Write("Enter your nickname: ");
string userName = ReadLine();

while (true)
{
    switch (ReadKey(true).Key)
    {

    }
}
    
UdpClient receiver = new UdpClient(localPort);
UdpClient sender = new UdpClient();

while (true)
{
    GameFigure my = await SendGameFigure();
    WriteLine("Waiting for the opponent...");
    GameFigure opponent = GameFigure.Empty;
    while ((int)opponent == 0)
    {
        opponent = await ReceiveGameFigure();
    }
    HandleGame(my, opponent);
    ReadLine();
}

async Task<GameFigure> SendGameFigure()
{

    WriteLine("|Select your figure|");
    GameFigure figure = SelectGameFigure();

    WriteLine($"Your figure: {figure}");

    string message = $"{userName} chose {figure}";
    byte[] data = Encoding.UTF8.GetBytes(message);

    await sender.SendAsync(data, new IPEndPoint(iPAddress, remotePort));
    return figure;
}
async Task<GameFigure> ReceiveGameFigure()
{
    
    var result = await receiver.ReceiveAsync();
    var message = Encoding.UTF8.GetString(result.Buffer);
    WriteLine(message);


    return (GameFigure)Enum.Parse(typeof(GameFigure), message.Split(' ', StringSplitOptions.RemoveEmptyEntries).Last());
}

void HandleGame(GameFigure my, GameFigure opponent)
{
    if ((int)my == 1 && (int)opponent == 2)
        WriteLine("You win!");
    else if ((int)my == 2 && (int)opponent == 3)
        WriteLine("You win!");
    else if ((int)my == 3 && (int)opponent == 1)
        WriteLine("You win!");
    else if ((int)my == (int)opponent)
        WriteLine("It's a draw!");
    else
        WriteLine("You lose!");
}
GameFigure SelectGameFigure()
{
    while (true)
    {
        WriteLine("Press:\n" +
            "Q - Stone | W - Scissors | E - Paper");
        switch (ReadKey(true).Key)
        {
            case ConsoleKey.Q:
                {
                    return GameFigure.Stone;
                }
            case ConsoleKey.W:
                {
                    return GameFigure.Scissors;
                }
            case ConsoleKey.E:
                {
                    return GameFigure.Paper;
                }
            default:
                {
                    WriteLine("Wrong option!");
                    break;
                }
        }
    }
}