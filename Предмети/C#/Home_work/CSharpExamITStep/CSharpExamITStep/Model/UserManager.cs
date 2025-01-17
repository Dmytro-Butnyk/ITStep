using CSharpExamITStep.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpExamITStep.Model
{
    public class UserManager
    {
        private List<Player> _players;
        private string _usersPath = "Players.json";

        public UserManager() 
        {
            if (File.Exists(_usersPath) && !string.IsNullOrEmpty(File.ReadAllText(_usersPath)))
            {
                string players = File.ReadAllText(_usersPath);
                _players = JsonConvert.DeserializeObject<List<Player>>(players);
            }
            else
            {
                _players = new List<Player>();
            }
        }
        public UserManager(string usersPath)
        {
            _usersPath = usersPath;
            if (File.Exists(_usersPath) && !string.IsNullOrEmpty(File.ReadAllText(_usersPath)))
            {
                string players = File.ReadAllText(_usersPath);
                _players = JsonConvert.DeserializeObject<List<Player>>(players);
            }
            else
            {
                _players = new List<Player>();
            }
        }

        public List<Player> Players
        {
            get { return _players; }
            set { _players = value; }
        }
        public string UsersPath
        {
            get { return _usersPath; }
            set { _usersPath = value; }
        }

        // LogIn
        #region
        public Player LogIn()
        {
            string login, password;

            Write("Enter login: ");
            if (!FindLogin(login = ReadLine()))
            {
                WriteLine("\nWrong login.");
                return null;
            }
            Write("Enter password: ");
            if (!FindPassword(password = ReadLine()))
            {
                WriteLine("\nWrong password.");
                return null;
            }
            WriteLine("Authorization is succesfully!");
            return _players.SingleOrDefault(p => p.Login == login && p.Password == password);
        }

        #endregion

        // SignIn
        #region
        public void SignIn()
        {
            Player newPlayer = new();
            newPlayer.Initialize();
            if (_players.Any(x => x.Login == newPlayer.Login))
            {
                WriteLine("Error: This login is busy.");
                return;
            }
            _players.Add(newPlayer);
            WriteLine("You are registered");
        }
        #endregion

        private bool FindLogin(string value)
        {
            return _players.Any(x => x.Login == value);
        }
        private bool FindPassword(string value)
        {
            return _players.Any(x => x.Password == value);
        }

        public void Save(Player player)
        {
            for (int i = 0; i < _players.Count(); ++i)
            {
                if (player.Equals(_players[i]))
                {
                    _players[i] = player;
                }
                else
                {
                    _players.Add(player);
                }
            }
            string players = JsonConvert.SerializeObject(_players);
            File.WriteAllText(_usersPath, players);
        }
        public void Save()
        {
            string players = JsonConvert.SerializeObject(_players);
            File.WriteAllText(_usersPath, players);
        }
    }
}
