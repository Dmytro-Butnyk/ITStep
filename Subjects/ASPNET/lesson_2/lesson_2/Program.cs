using System.Text.Json;
using lesson_2;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

User _user;

app.MapGet("/", async x =>
{
    x.Response.ContentType = "text/html; charset=utf-8";
    await x.Response.SendFileAsync("HTML/index.html");
});
app.MapPost("/", async context =>
{
    var form = context.Request.Form;
    var login = form["login"];
    var password = form["password"];
    
    // Читаємо та десеріалізуємо користувачів асинхронно
    List<User>? users = await GetUsersAsync("Users/Users.json");

    if (users != null && users.Any(user => user.Login == login && user.Password == password))
    {
        _user = users.First(user => user.Login == login);
        context.Response.Redirect("/user_page");
    }
    else
    {
        context.Response.Redirect("/");
    }
});

static async Task<List<User>?> GetUsersAsync(string filePath)
{
    if (File.Exists(filePath))
    {
        var fileContent = await File.ReadAllTextAsync(filePath);
        if (!string.IsNullOrWhiteSpace(fileContent))
        {
            return JsonSerializer.Deserialize<List<User>>(fileContent);
        }
    }
    return new List<User>();
}


app.MapGet("/registration", async x =>
{
    x.Response.ContentType = "text/html; charset=utf-8";
    await x.Response.SendFileAsync("HTML/registration.html");
});

app.MapPost("/registration", async x =>
{ 
    var form = x.Request.Form;
    
    List<User>? users = new();
    if(string.IsNullOrWhiteSpace(await File.ReadAllTextAsync("Users/Users.json")))
    {
        users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText("Users/Users.json"));
    }
    
    if(users != null && users.Any(user => user.Login == form["login"] || string.IsNullOrWhiteSpace(form["login"])
                                                                || string.IsNullOrWhiteSpace(form["password"])))
    {
        x.Response.Redirect("/registration");
    }
    else
    {
        if (form["password"] == form["submitPassword"])
        {
            users?.Add(new User(form["login"], form["password"]));
            File.WriteAllText("Users/Users.json", JsonSerializer.Serialize(users));
            x.Response.Redirect("/");
        }
        else return;
    }
});


app.Run();
