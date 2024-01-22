using FluentValidation;

namespace HRSOFT.Application.Feature.Commands.Employee
{
    public class AbstractEmployeeValidation<T> : AbstractValidator<T> where T : EmployeeAbstract
    {
        public AbstractEmployeeValidation()
        {
            RuleFor(c => c.Name)
              .NotEmpty()
              .WithMessage("Name: Required");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("LastName: Required");

            RuleFor(c => c.DateOfBirht)
                .NotEmpty()
                .WithMessage("DateOfBirht: Required");

            RuleFor(c => c.Position)
                .NotEmpty()
                .WithMessage("Position: Required");

            RuleFor(c => c.Email)
           .NotEmpty()
           .WithMessage("Email: Required");

            RuleFor(x => x.PrivateNumber)
                .NotEmpty()
                .WithMessage("PrivateNumber : required")
                .Length(11)
                .WithMessage("PrivateNumber must be 11 characters long");

            RuleFor(c => c.MobileNumber)
                .NotEmpty()
                .WithMessage("MobileNumber: Required");

            RuleFor(c => c.Status)
             .NotEmpty()
             .WithMessage("Status: Required");
        }
    }

}
