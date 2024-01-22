using MediatR;

namespace HRSOFT.Application.Feature.Commands.Employee.Delete
{
    public class EmployeeDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

}
