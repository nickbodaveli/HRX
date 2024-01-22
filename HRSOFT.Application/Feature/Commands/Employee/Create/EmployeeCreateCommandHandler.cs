using HRSOFT.Application.Common.Interfaces;
using MediatR;

namespace HRSOFT.Application.Feature.Commands.Employee.Create
{
    public class EmployeeCreateCommandHandler : IRequestHandler<EmployeeCreateCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeCreateCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByEmailOrPrivateNumber(request.Email, request.PrivateNumber);

            if(employee)
            {
                return false;
            }

            var newEmployee = HRSOFT.Domain.Common.Employee.Create(request.PrivateNumber, request.Name, request.LastName, request.DateOfBirht, request.Position, request.FreedDate, request.MobileNumber, request.Email, request.Status);

            var createEmployee = await _employeeRepository.CreateEmployee(newEmployee);

            return createEmployee == true;
        }
    }

}
