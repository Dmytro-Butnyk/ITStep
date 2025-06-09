using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lesson_14.Task_2
{
    public class Actor
    {
        string _name = "NoName";
        string _lastName = "NoLastName";
        uint _age = 0;

        private bool _disposed = false;
        public Actor() { }
        public Actor(string name, string lastName, uint age)
        {
            _name = name;
            _lastName = lastName;
            _age = age;
        }
        // properties
        #region
        public string Name
        {
            get { return _name; }
            set 
            {
                if (value.Any(c => char.IsDigit(c)))
                    throw new Exception("Wrong name");
                _name = value; 
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                if (value.Any(c => char.IsDigit(c)))
                    throw new Exception("Wrong name");
                _lastName = value; 
            }
        }
        public int Age
        {
            get { return (int)_age; }
            set
            {
                if (value <= 0)
                    throw new Exception("Wrong age");
                _age = (uint)value;
            }
        }
        #endregion
        public void Init()
        {
            WriteLine("Type name:");
            Name = ReadLine();
            WriteLine("Type last name:");
            LastName = ReadLine();
            WriteLine("Type age:");
            Age = int.Parse(ReadLine());
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                }

                _disposed = true;
            }
        }
        public override string ToString()
        {
            return $"Name: {_name} | Last name: {_lastName} | Age: {_age}";
        }
    }
}
