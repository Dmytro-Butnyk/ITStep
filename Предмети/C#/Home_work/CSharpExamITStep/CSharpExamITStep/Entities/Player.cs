using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpExamITStep.Entities
{
    public class Player
    {
        private string _login = "NoLogin";
        private string _password = "NoPassword";
        private DateOnly _birthDate = new();
        private List<QuizResult> _quizResults = new();
        public Player() { }
        public Player(string login, string password, DateOnly birthDate, List<QuizResult> quizResults)
        {
            _login = login;
            _password = password;
            _birthDate = birthDate;
            _quizResults = quizResults;
        }
        public Player(string login, string password, DateOnly birthDate)
        {
            _login = login;
            _password = password;
            _birthDate = birthDate;
        }
        public string Login
        {
            get { return _login; }
            set
            {
                if (value == null || value.Length < 6)
                    throw new Exception("Wrong login value. Login can`t be null or empty.");
                _login = value;
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                string pattern = "^(?=.*[A-Z])(?=.*\\d).{5,}$";
                Regex passwordRegex = new(pattern);
                if (passwordRegex.IsMatch(value))
                    _password = value;
            }
        }
        public DateOnly BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        public List<QuizResult> QuizResults
        {
            get { return _quizResults; }
            set
            {
                _quizResults = value;
            }
        }
        public void Initialize()
        {
            Write("Enter login (at leats 6 symbols): ");
            Login = ReadLine();
            Write("\nEnter password (at least 5 symbols, one upper letter and one digit): ");
            Password = ReadLine();
            Write("\nEnter your birth date (dd/MM/yyyy): ");
            BirthDate = DateOnly.Parse(ReadLine());
            WriteLine("OK");
        }
        public void ShowResults()
        {
            WriteLine($"Quiz results:\n{ string.Join("\n", _quizResults)}");
        }
        public override string ToString()
        {
            return $"Login: {_login} | Password: {_password} | Birth date: {_birthDate.ToString("dd.MM.yyyy")} |\nQuiz results:\n{string.Join("\n", _quizResults)} |";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Player other = (Player)obj;
            return _login == other._login && _password == other._password && _birthDate == other._birthDate;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_login, _password, _birthDate);
        }
    }
}
