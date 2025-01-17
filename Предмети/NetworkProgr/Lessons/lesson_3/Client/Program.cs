using Client;
using static System.Console;


try
{
    QuoteClient quoteClient = new("127.0.0.1", 1488);
    await quoteClient.Connect();
}
catch(Exception ex)
{
    WriteLine(ex.Message);
}