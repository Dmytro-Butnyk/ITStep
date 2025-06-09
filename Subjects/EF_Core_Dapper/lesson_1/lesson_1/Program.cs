using lesson_1;
using Microsoft.Data.SqlClient;
using static System.Console;

SqlProg pr = new();

WriteLine("Enter product name:");
pr.ShowProduct(ReadLine());
pr.ShowProductTypes();


