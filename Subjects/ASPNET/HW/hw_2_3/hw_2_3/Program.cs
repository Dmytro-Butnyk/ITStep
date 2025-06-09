using hw_2_3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

GuessTheNumber gtn = new GuessTheNumber();

app.MapGet("/", async x =>
{
    x.Response.ContentType = "text/html";
    await x.Response.SendFileAsync("Views/index.html");
});

#region GUESS THE NUMBER
app.MapGet("/guess", async x =>
{
    x.Response.ContentType = "text/html";
    await x.Response.SendFileAsync("Views/guessTheNumberMain.html"); 
});

app.MapGet("/backToGuess", async x =>
{
    x.Response.ContentType = "text/html";
    await x.Response.SendFileAsync("Views/guessTheNumberMain.html"); 
});

app.MapGet("/genNewNum", async x =>
{
    await gtn.GenerateNumberAsync();
    x.Response.Redirect("/guess");
});

app.MapPost("/guThNuRes", async x =>
{
    var form = await x.Request.ReadFormAsync();
    int clientNum;
    if (!int.TryParse(form["clientNum"], out clientNum))
    {
        x.Response.Redirect("/guess");
    }
    else
    {
        string result = await gtn.GameProcessAsync(clientNum);
        x.Response.ContentType = "text/html";
        await x.Response.WriteAsync("<!DOCTYPE html>\n" +
                                    "<html lang=\"en\">\n" +
                                    "<head>\n" +
                                    "    <meta charset=\"UTF-8\">\n" +
                                    "    <title>Title</title>\n" +
                                    "</head>\n" +
                                    "<body>\n" +
                                    "\n<div>\n" +
                                    $"    <h1>{result}</h1>\n" +
                                    "    <form action=\"/backToGuess\">\n" +
                                    "        <input type=\"submit\" value=\"GO BACK\">\n" +
                                    "    </form>\n" +
                                    "</div>\n" +
                                    "\n</body>\n" +
                                    "</html>");
    }
});
#endregion

#region TIC TAC TOE

app.MapGet("/ticTacToe", async x =>
{
    x.Response.ContentType = "text/html";
    await x.Response.SendFileAsync("");
});

#endregion

app.Run();