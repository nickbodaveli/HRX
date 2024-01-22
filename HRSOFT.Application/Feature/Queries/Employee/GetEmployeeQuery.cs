using MediatR;

namespace HRSOFT.Application.Feature.Queries.Employee
{
    public class GetEmployeeQuery: IRequest<HRSOFT.Domain.Common.Employee>
    {
        public int Id { get; set; }
    }
}
