using MediatR;

namespace HRSOFT.Application.Feature.Queries.Employee
{
    public class GetEmployeesQuery : IRequest<List<HRSOFT.Domain.Common.Employee>>
    {
    }
}
