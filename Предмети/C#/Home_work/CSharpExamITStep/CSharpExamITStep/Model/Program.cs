using CSharpExamITStep.Entities;
using CSharpExamITStep.Enums;
using CSharpExamITStep.Model;
using System.Net.Quic;
using static System.Console;

UserManager userManager = new();
Player player = null;

bool isRegistered = false;
while (!isRegistered)
{
    Clear();

    WriteLine("Enter" +
        "\n1 - to LogIn;" +
        "\n2 - to SignIn;" +
        "\n0 - exit:");

    switch (ReadKey(true).Key)
    {
        case ConsoleKey.D1:
            {
                player = userManager.LogIn();
                if (player == null)
                {
                    WriteLine("Wrong data.");
                    ReadKey();
                }
                isRegistered = true;
                break;
            }
        case ConsoleKey.D2:
            {
                userManager.SignIn();
                userManager.Save();
                WriteLine("Now you need to LogIn.");
                ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                Environment.Exit(0);
                break;
            }
        default:
            {
                WriteLine("Wrong choice!");
                ReadKey();
                break;
            }
    }
}

QuizProcess quizProcess = new(player);

while (true)
{
    WriteLine("Enter" +
        "\n1 - to start quiz;" +
        "\n2 - to show your results;" +
        "\n3 - to show top 20 in subject;" +
        "\n0 - exit:");

    switch(ReadKey(true).Key)
    {
        case ConsoleKey.D1:
            {
                Subjects subject;
            //
            D:
                WriteLine("Enter" +
                    "\n1 - Math;" +
                    "\n2 - Environment;" +
                    "\n3 - Geography:");
                switch (ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        {
                            subject = Subjects.Math;
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            subject = Subjects.Environment;
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            subject = Subjects.Geography;
                            break;
                        }
                    default:
                        {
                            WriteLine("Wrong choice!");
                            goto D;
                        }
                }
                quizProcess.Subject = new Subject(subject);
                quizProcess.StartQuiz();
                userManager.Save(player);
                break;
            }
        case ConsoleKey.D2:
            {
                player.ShowResults();
                break;
            }
        case ConsoleKey.D3:
            {
                userManager.Save(player);
                quizProcess.ShowTop(userManager);
                break;
            }
        case ConsoleKey.D0:
            {
                Environment.Exit(0);
                break;
            }
        default:
            {
                WriteLine("Wrong choice!");
                break;
            }
    }
}