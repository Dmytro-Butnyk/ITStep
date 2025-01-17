using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLibrary
{
    public static class UserClass
    {
        public static bool IsValidName(string name)
        {
            return name.All(char.IsLetter);
        }

        public static bool IsValidAge(string age)
        {
            return age.All(char.IsDigit) && int.Parse(age) >= 0;
        }
        /// <summary>
        /// Example: +38(050)123-45-67
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\+\d{2}\(\d{3}\)\d{3}-\d{2}-\d{2}$");
        }
        /// <summary>
        /// Example: email@example.com
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
