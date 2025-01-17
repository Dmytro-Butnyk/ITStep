// task 1

//using System.Diagnostics;

//Process childProcess = new Process();
//childProcess.StartInfo.FileName = "notepad.exe";

//childProcess.Start();

//Console.WriteLine("Press 'q' to stop the process or any other key to wait till the end...");

//if (Console.ReadKey().KeyChar == 'q')
//{
//    childProcess.Kill();
//}
//else
//{
//    childProcess.WaitForExit();
//}

//Console.WriteLine($"Child process stoped. Code: {childProcess.ExitCode}");

// task 2

//using System.Diagnostics;

//static void Main(string[] args)
//{
//    Process childProcess = new Process();
//    childProcess.StartInfo.FileName = @"..\..\..\ChildProcess\bin\Debug\net8.0\ChildProcess.exe"; 
//    childProcess.StartInfo.Arguments = "7 3 +";

//    childProcess.Start();
//    childProcess.WaitForExit();
//}

// task 3

using System.Diagnostics;

Process childProcess = new Process();
childProcess.StartInfo.FileName = @"..\..\..\ChildProcess\bin\Debug\net8.0\ChildProcess.exe";
childProcess.StartInfo.Arguments = @"O:\someFolder bicycle";

childProcess.Start();
childProcess.WaitForExit();
    
