using System;
using System.Collections.Generic;

namespace lesson_12_2
{
    public class EmployeeManagement(Dictionary<string, string> employeePasswords)
    {
        private Dictionary<string, string> _employeePasswords = employeePasswords;

        public void AddEmployee(string login, string password)
        {
            if (!_employeePasswords.ContainsKey(login))
            {
                _employeePasswords.Add(login, password);
            }
            else
            {
                throw new Exception("Employee already exists.");
            }
        }

        public void RemoveEmployee(string login)
        {
            if (_employeePasswords.ContainsKey(login))
            {
                _employeePasswords.Remove(login);
            }
            else
            {
                throw new Exception("Employee does not exist.");
            }
        }

        public void UpdateEmployee(string login, string newPassword)
        {
            if (_employeePasswords.ContainsKey(login))
            {
                _employeePasswords[login] = newPassword;
            }
            else
            {
                throw new Exception("Employee does not exist.");
            }
        }

        public string GetPassword(string login)
        {
            if (_employeePasswords.ContainsKey(login))
            {
                return _employeePasswords[login];
            }
            else
            {
                throw new Exception("Employee does not exist.");
            }
        }
        public void PrintAllEmployees()
        {
            foreach (var employee in _employeePasswords)
            {
                Console.WriteLine($"Login: {employee.Key}, Password: {employee.Value}");
            }
        }
    }
}