using HRSOFT.Application.Common.Interfaces;
using MediatR;

namespace HRSOFT.Application.Feature.Commands.Employee.Delete
{
    public class EmployeeDeleteCommandHandler : IRequestHandler<EmployeeDeleteCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeDeleteCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployee(request.Id);

            if(employee != null)
            {
                await _employeeRepository.DeleteEmployee(employee);
                return true;
            }

            return false;
        }
    }

}
