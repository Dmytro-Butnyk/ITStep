using Server;
using static System.Console;

try
{
    QuoteServer quoteServer = new("127.0.0.1", 1488);
    await quoteServer.Start();
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}