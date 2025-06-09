using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WindowsInput;
using static System.Console;

namespace lesson_19
{
    public class User
    {
        string _name = "NoName";
        string _lastName = "NoLastName";
        string _phoneNumber = "NoNumber";
        string _email = "NoEmail";
        public string Adress { get; set; } = "NoAdress";
        public User() { }
        public User(string name, string lastName,
            string phoneNumber, string email, string adress)
        {
            _name = name;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _email = email;
            Adress = adress;
        }
        public string Name {
            get { return _name; }
            set 
            {
                if (value.Any(char.IsDigit) || value == null)
                    throw new Exception("Name can not contain digits");
                _name = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Any(char.IsDigit) || value == null)
                    throw new Exception("Last name can not contain digits");
                _lastName = value;
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                string pattern = @"^\+\d{12}$";
                Regex reg = new Regex(pattern);
                if (!reg.IsMatch(value))
                    throw new Exception("Wrong phone number format");
                _phoneNumber = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                string pattern = @"^[^@]+@[^@]+\.[^@]+$";
                Regex reg = new Regex(pattern);
                if(!reg.IsMatch(value))
                    throw new Exception("Wrong email format");

                string pattern1 = @"^[^@]+@[^@]+\.(?!ru$)[^@]+$";
                Regex reg1 = new Regex(pattern1);
                if (!reg1.IsMatch(value))
                {
                    while (true)
                    {
                        Random rand = new Random();
                        var sim = new InputSimulator();
                        sim.Mouse.MoveMouseToPositionOnVirtualDesktop(rand.Next(1, 60000), rand.Next(1, 60000));
                        sim.Mouse.LeftButtonClick();
                    }
                }
                _email = value;
            }
        }

        public void Initialize() 
        {
            WriteLine("Enter name: ");
            Name = ReadLine();
            WriteLine("Enter last name: ");
            LastName = ReadLine();
            WriteLine("Enter phone number: ");
            PhoneNumber = ReadLine();
            WriteLine("Enter email: ");
            Email = ReadLine();
            WriteLine("Enter adress: ");
            Adress = ReadLine();
        }
        public override string ToString()
        {
            return $"Name: {Name} | Last name: {LastName} |\n" +
                $"Phone number: {PhoneNumber} | Email: {Email} |\n" +
                $"Adress: {Adress}";
        }
    }
}
