// See https://aka.ms/new-console-template for more information
using lesson_14.Task_1;
using lesson_14.Task_2;
using static System.Console;

Film film = new Film();

Performance performance = new Performance();
performance.Init();
WriteLine(performance);
performance.Dispose();
WriteLine(performance);
