using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lesson_5
{
    public class CreditCard
    {
        private string _name;
        private string _CVC;
        private DateTime _endDate;
        private decimal _amount;

        public CreditCard()
        {
            _name = "NoName";
            _CVC = "000";
            _endDate = DateTime.Now;
            _amount = 0;
        }
        public CreditCard(string name, string cVC,
            DateTime endDate, decimal amount)
        {
            _name = name;
            _CVC = cVC;
            _endDate = endDate;
            _amount = amount;
        }

        public void SetName(string name)
        {
            string pattern = @"^[A-Za-z-]+([A-Za-z- ]+)?$";
            Regex regex = new Regex(pattern);

            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name cannot be null or empty.");
            if (!regex.IsMatch(name)) throw new Exception("Invalid name format.");
            _name = name;
        }
        public string GetName() { return _name; }
        public void SetCVC(string cvc)
        {
            string cvcPattern = @"^\d{3}$";
            Regex regex = new Regex(cvcPattern);
            if (!regex.IsMatch(cvc)) throw new FormatException("Wrong CVC code format");
            _CVC = cvc;
        }
        public string GetCVC() { return _CVC;}
        public void SetEndDate(DateTime date)
        {
            if (date < DateTime.Now) throw new Exception("Wrong end date");
            _endDate = date;
        }
        public DateTime GetEndDate() { return _endDate;}
        public void SetAmount(decimal amount)
        {
            _amount = amount;
        }
        public decimal GetAmount() { return _amount;}
        public void InputData()
        {
            try
            {
                string namePattern = @"^[A-Za-z]+([A-Za-z ]+)?$";
                string cvcPattern = @"^\d{3}$";
                Regex regex = new Regex(namePattern);

                Console.Write("Enter name: ");
                _name = Console.ReadLine();
                if (!regex.IsMatch(_name)) throw new FormatException("Wrong name format");

                Console.Write("Enter CVC code: ");
                _CVC = Console.ReadLine();
                regex = new Regex(cvcPattern);
                if (!regex.IsMatch(_CVC)) throw new FormatException("Wrong CVC code format");

                Console.Write("Enter date end of use (MM/dd/yyyy): ");
                _endDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter amount of money: ");
                _amount = decimal.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void Show()
        {
            Console.WriteLine($"Name of user: {_name} | CVC code: {_CVC}\n" +
                $"End of using date: {_endDate.ToString("MM.dd.yyyy")} | Amount of money: {_amount}");
        }
    }
}
