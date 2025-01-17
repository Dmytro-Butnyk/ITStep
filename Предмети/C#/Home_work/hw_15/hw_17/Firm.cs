using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_17
{
    public class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorName { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; }
        public Firm(string name, DateTime foundationDate, string businessProfile,
            string directorName, int employeeCount, string address, List<Employee> employees)
        {
            Name = name;
            FoundationDate = foundationDate;
            BusinessProfile = businessProfile;
            DirectorName = directorName;
            EmployeeCount = employeeCount;
            Address = address;
            Employees = employees ?? throw new ArgumentNullException(nameof(employees));
        }

        public override string ToString()
        {
            return $"Name: {Name} | Foundation date: {FoundationDate.ToString("dd/MM/yyyy")} | " +
                $"BusinessProfile: {BusinessProfile} | DirectorName: {DirectorName} | " +
                $"EmployeeCount: {EmployeeCount} | Address: {Address}";
        }
    }
}
