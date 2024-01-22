using FluentValidation;
using HRSOFT.Application.Feature.Commands.Authentication.Register;

namespace HRSOFT.Application.Feature.Commands.Authentication
{
    public class UserRegisterValidation : AbstractValidator<UserRegisterCommand>
    {
        public UserRegisterValidation()
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

            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage("Password: Required");

            RuleFor(c => c.RepeatPassword)
                .NotEmpty()
                .WithMessage("RepeatPassword: Required")
                .Equal(c => c.Password) // Check if RepeatPassword is equal to Password
                .WithMessage("Passwords do not match");

            RuleFor(x => x.PrivateNumber)
                .NotEmpty()
                .WithMessage("PrivateNumber: Required")
                .Length(11)
                .WithMessage("PrivateNumber must be 11 characters long");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithErrorCode("Email is Required")
                .EmailAddress()
                .WithMessage("Invalid value email address");
        }
    }
}
