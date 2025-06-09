using static System.Console;
using lesson_19;

try
{
    UserAccessManager userAccess = new();
    string choice = "1";
    userAccess.ReadUsers();
    while (true)
    {
        WriteLine("Press:\n" +
            "1 - to authorize;\n" +
            "2 - to register;\n" +
            "0 - to exit.\n");
        switch (ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                {
                    userAccess.Authorizaton();
                    break;
                }
            case ConsoleKey.D2:
                {
                    userAccess.Registration();
                    userAccess.WriteUsers();
                    break;
                }
            case ConsoleKey.D0:
                {
                    userAccess.WriteUsers();
                    Environment.Exit(0);
                    break;
                }
        }
    }
}
catch(Exception ex)
{
    WriteLine(ex.Message);
}