using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_11
{
    public record Person(string firstName, string lastName, int age);

    public static class PersonExtensions
    {
        public static double AverageAge(this Person[] people)
        {
            return people.Average(person => person.age);
        }
        public static Person MaxAge(this Person[] people)
        {
            return people.OrderBy(person => person.age).Last();
        }
        public static Person MinAge(this Person[] people)
        {
            return people.OrderBy(person => person.age).First();
        }
    }
}
