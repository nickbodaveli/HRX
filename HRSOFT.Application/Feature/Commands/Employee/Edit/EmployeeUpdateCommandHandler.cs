using HRSOFT.Application.Common.Interfaces;
using MediatR;

namespace HRSOFT.Application.Feature.Commands.Employee.Edit
{
    public class EmployeeUpdateCommandHandler : IRequestHandler<EmployeeUpdateCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeUpdateCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployee(request.Id);
            employee.Name = request.Name;   
            employee.LastName = request.LastName;   
            employee.PrivateNumber = request.PrivateNumber;   
            employee.FreedDate = request.FreedDate;   
            employee.DateOfBirht = request.DateOfBirht;   
            employee.MobileNumber = request.MobileNumber;   
            employee.Status = request.Status;   
            employee.Position = request.Position;
            employee.Email = request.Email;

            await _employeeRepository.UpdateEmployee(employee);

            return true;
        }
    }

}
