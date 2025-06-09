using System;
using System.Diagnostics;
using static System.Console;

// task 1
/*
Process[] processlist = Process.GetProcesses();

WriteLine("List of process:");
foreach (Process process in processlist)
{
        WriteLine("ID: {0}  Name: {1}", process.Id, process.ProcessName);
// task 2
    try
    {
        WriteLine("Start time: " + process.StartTime);
        WriteLine("Overall process time: " + process.TotalProcessorTime);
        WriteLine("Threads count: " + process.Threads.Count);
    }
    catch (Exception ex)
    {
        WriteLine("Failed to receive the info: " + ex.Message);
    }
    WriteLine();
}
*/

// task 3

while (true)
{
    WriteLine("Enter the number to open:");
    WriteLine("1 - Notepad");
    WriteLine("2 - Calculator");
    WriteLine("3 - Paint");
    WriteLine("0 - Exit");


    switch (ReadLine())
    {
        case "1":
            Process.Start("notepad.exe");
            break;
        case "2":
            Process.Start("calc.exe");
            break;
        case "3":
            Process.Start("mspaint.exe");
            break;
        case "0":
            return;
        default:
            WriteLine("Wrong command.");
            break;
    }
}
    


