using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lesson_12
{
    public record Worker
        (string Name, string Position,
        decimal Salary, string Email);
   
    public static class WorkerTools
    {
       public static void AddWorker(string name, string position,
    decimal salary, string email, ref List<Worker> workers)
        {
            if (name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length != 3 || name.Any(char.IsDigit))
                throw new Exception("Wrong name.");
            if (position.Any(char.IsDigit))
                throw new Exception("Wrong position.");
            if (salary < 0)
                throw new Exception("Salary can`t be less than zero.");
            if (!email.Contains('@') || email.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length != 1)
                throw new Exception("Wrong format of email.");

            workers.Add(new Worker(name, position, salary, email));
            WriteLine("Worker added!");
        }
        public static void DeleteWorker(ref List<Worker> workers, int index)
        {
            if (index < 0 || index >= workers.Count())
                throw new Exception("Index out of workers list.");
            workers.Remove(workers[index]);
            WriteLine("Worker added!");
        }
        public static void ChangeWorker(int index, ref List<Worker> workers)
        {
            if (index < 0 || index >= workers.Count())
                throw new Exception("Index out of workers list.");
            WriteLine("Enter new name, position, salary, email\n" +
                "one by one after 'enter':");
            workers.Add(NewWorker(ReadLine(), ReadLine(), decimal.Parse(ReadLine()), ReadLine()));
            WriteLine("Worker changed.");
        }
        private static Worker NewWorker(string name, string position,
            decimal salary, string email)
        {
            if (name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length != 3 || name.Any(char.IsDigit))
                throw new Exception("Wrong name.");
            if (position.Any(char.IsDigit))
                throw new Exception("Wrong position.");
            if (salary < 0)
                throw new Exception("Salary can`t be less than zero.");
            if (!email.Contains('@') || email.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length != 1)
                throw new Exception("Wrong format of email.");

            return new Worker(name, position, salary, email);
        }
        public static void FindByName(string name, List<Worker> workers)
        {
            workers.Where(x => x.Name == name)?
                .ToList().ForEach(WriteLine);
        }
        public static void SortByPosition(ref List<Worker> workers)
        {
            workers.Sort((w1, w2) =>
            w1.Position.CompareTo(w2.Position));
            WriteLine("Sorted by position.");
        }
    }
}
