using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_6
{
    public class Resume
    {
        public string FullName { get; set; }
        public string City { get; set; }
        public int YearsOfExperience { get; set; }
        public string[] Skills { get; set; }
        public int ExpectedSalary { get; set; }

        public Resume(string fullName, string city, int yearsOfExperience, string[] skills, int expectedSalary)
        {
            FullName = fullName;
            City = city;
            YearsOfExperience = yearsOfExperience;
            Skills = skills;
            ExpectedSalary = expectedSalary;
        }

        public override string ToString()
        {
            return $"Full Name: {FullName}\nCity: {City}\nYears of Experience: {YearsOfExperience}\nSkills: {string.Join(", ", Skills)}\nExpected Salary: {ExpectedSalary}";
        }
    }

}
