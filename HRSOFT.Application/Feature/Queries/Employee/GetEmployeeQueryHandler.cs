using HRSOFT.Application.Common.Interfaces;
using MediatR;

namespace HRSOFT.Application.Feature.Queries.Employee
{
	public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, HRSOFT.Domain.Common.Employee>
	{
		private readonly IEmployeeRepository _employeeRepository;

		public GetEmployeeQueryHandler(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public async Task<Domain.Common.Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
		{
			var employee = await _employeeRepository.GetEmployee(request.Id);

			return employee;
		}
	}
}
