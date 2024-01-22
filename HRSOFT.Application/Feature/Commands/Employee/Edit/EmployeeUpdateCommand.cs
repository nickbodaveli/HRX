using MediatR;

namespace HRSOFT.Application.Feature.Commands.Employee.Edit
{
    public class EmployeeUpdateCommand : EmployeeAbstract, IRequest<bool>
    {
        public int Id { get; set; }
    }

}
