using HRSOFT.Application.Common.Interfaces;
using MediatR;

namespace HRSOFT.Application.Feature.Queries.Employee
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<HRSOFT.Domain.Common.Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<HRSOFT.Domain.Common.Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployees();
        }
    }
}
