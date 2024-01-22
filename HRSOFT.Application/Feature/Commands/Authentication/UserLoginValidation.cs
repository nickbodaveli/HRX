using FluentValidation;
using HRSOFT.Application.Feature.Commands.Authentication.Login;

namespace HRSOFT.Application.Feature.Commands.Authentication
{
    public class UserLoginValidation : AbstractValidator<UserLoginCommand>
    {
        public UserLoginValidation()
        {
            RuleFor(c => c.UserName)
              .NotEmpty()
              .WithMessage("Name: Required");

            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage("Password: Required");
        }
    }
}
