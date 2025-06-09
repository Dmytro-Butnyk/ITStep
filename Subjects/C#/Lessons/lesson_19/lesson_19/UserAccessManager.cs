using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lesson_19
{
    public class UserAccessManager
    {
        private List<User> _users = new();
        private string _jsonPath = "Users.json";

        public UserAccessManager() { }

        public void ReadUsers()
        {
            if (!File.Exists(_jsonPath))
                return;
            string json = File.ReadAllText(_jsonPath);
            _users = JsonConvert.DeserializeObject<List<User>>(json);
        }
        public void WriteUsers()
        {
            string json = JsonConvert.SerializeObject(_users);
            File.WriteAllText(_jsonPath, json);
        }
        public bool Authorizaton()
        {
            Write("Enter name: ");
            if (!FindName(ReadLine()))
            {
                WriteLine("\nWrong name.");
                return false;
            }
            Write("Enter email: ");
            if (!FindEmail(ReadLine()))
            {
                WriteLine("\nWrong email.");
                return false;
            }
            WriteLine("Authorization is succesfully!");
            return true;
        }
        public void Registration()
        {
            User newUser = new();
            newUser.Initialize();
            if(_users.Any(x => x.ToString() == newUser.ToString()))
            {
                WriteLine("Error: This user exists.");
                return;
            }
            _users.Add(newUser);
            WriteLine("You are registered");
        }
        private bool FindName(string value)
        {
            return _users.Any(x => x.Name == value);
        }
        private bool FindEmail(string value)
        {
            return _users.Any(x => x.Email == value);
        }
    }
}
