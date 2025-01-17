using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDataBase.Models.ClientDetails
{
    public class Client
    {
        public int Id { get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }

        public Client() { }
        public Client (string login, string password)
        {
            Login = login;
            Password = password;
        }

        public override string ToString() =>
            $"Login: {Login}| Password: {Password}";
    }
}
