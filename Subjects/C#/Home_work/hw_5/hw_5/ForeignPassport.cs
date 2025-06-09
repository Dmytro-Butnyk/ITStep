using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw_5
{
    public class ForeignPassport
    {
        private string _id;
        private string _name;
        private DateTime _startDate;

        public ForeignPassport()
        {
            _id = "";
            _name = "";
            _startDate = DateTime.Now;
        }
        public ForeignPassport(string id, string name, DateTime startDate)
        {
            _id = id;
            _name = name;
            _startDate = startDate;
        }
        public ForeignPassport(string id, string name, string startDate)
        {
            _id = id;
            _name = name;
            _startDate = DateTime.Parse(startDate);
        }
        public string ID
        {
            get { return _id; }
        }
        public string Name
        {
            get { return _name;}
        }
        public DateTime StartDate
        {
            get { return _startDate; }
        }
        public void Initiate()
        {
            bool isRight = false;
            while (!isRight)
            {
                WriteLine("Initializing foreign passport.");
                WriteLine("Input card ID (5 digit code):");
                _id = ReadLine().Trim();
                if (_id.Length == 5 && !_id.Any(char.IsLetter))
                    isRight = true;
                else
                {
                    WriteLine("Wrong value. ID should be a 5 digit code.");
                    isRight = false;
                }
                WriteLine("Input last name, name and father name:");
                _name = ReadLine().Trim();
                if (!_name.Any(char.IsDigit))
                    isRight = true;
                else
                {
                    WriteLine("Wrong value. Name should not contain digits.");
                    isRight = false;
                }
                WriteLine("Input date of creating card (yyyy/mm/dd):");
                if (!DateTime.TryParse(ReadLine().Trim(), out _startDate))
                {
                    isRight = false;
                    WriteLine("Wrong value. Please input date in the format yyyy/mm/dd.");
                }
            }
            Clear();
        }
        public override string ToString()
        {
            return $"Name: {_name} | ID: {_id} |" +
                $" Start date: {_startDate.ToString("dd/MM/yyyy")}";
        }
    }
}
