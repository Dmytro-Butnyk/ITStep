// See https://aka.ms/new-console-template for more information
using static System.Console;
using lesson_12_2;


try
{
    var employeePasswords = new Dictionary<string, string>();
    var employeeManagement = new EmployeeManagement(employeePasswords);

    employeeManagement.AddEmployee("login1", "password1");

    WriteLine(employeeManagement.GetPassword("login1"));

    employeeManagement.UpdateEmployee("login1", "newPassword1");

    WriteLine(employeeManagement.GetPassword("login1"));

    employeeManagement.PrintAllEmployees();

    employeeManagement.RemoveEmployee("login1");
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}
