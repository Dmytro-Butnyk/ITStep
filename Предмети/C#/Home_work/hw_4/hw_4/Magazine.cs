using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_4
{
    public class Magazine(string name, int year,
        string description, string phoneNumber,
        string email)
    {
        private string _name = name;
        private int _year = year;
        private string _description = description;
        private string _phoneNumber = phoneNumber;
        private string _email = email;

        public string Name
        {
            get { return _name; }
        }
        public int Year
        {
            get { return _year; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public override string ToString()
        {
            return $"Name: {_name} | Year: {_year}\n" +
                $"Phone number: {_phoneNumber} | Email: {_email}\n" +
                $"Description: {_description}";
        }
    }
}
