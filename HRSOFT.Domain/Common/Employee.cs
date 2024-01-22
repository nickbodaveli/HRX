using HRSOFT.Domain.Common.Models;

namespace HRSOFT.Domain.Common
{
    public class Employee : AggregateRoot
    {
        public int Id { get; set; }
        public string PrivateNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirht { get; set; }
        public string Position { get; set; }
        public EmployeeStatus Status { get; set; }
        public string? FreedDate { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }

        public Employee()
        {

        }

        private Employee(string privateNumber, string name, string lastName, DateTime dateOfBirht, string position, string? freedDate, string mobileNumber, string email, EmployeeStatus status)
        {
            PrivateNumber = privateNumber;
            Name = name;
            LastName = lastName;
            DateOfBirht = dateOfBirht;
            Position = position;
            FreedDate = freedDate;
            MobileNumber = mobileNumber;
            Email = email;
            Status = status;
        }

        public static Employee Create(string privateNumber, string name, string lastName, DateTime dateOfBirht, string position, string? freedDate, string mobileNumber, string email, EmployeeStatus status)
        {
            return new Employee(privateNumber, name, lastName, dateOfBirht, position, freedDate, mobileNumber, email, status);
        }
    }
}
