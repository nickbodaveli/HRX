using HRSOFT.Domain;

namespace HRSOFT.Application.Feature.Commands.Employee
{
    public class EmployeeAbstract
    {
        public string PrivateNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirht { get; set; }
        public string Position { get; set; }
        public string? FreedDate { get; set; }
        public string MobileNumber { get; set; }
        public EmployeeStatus Status { get; set; }

    }
}
