using HRSOFT.Domain.Common;
using MediatR;

namespace HRSOFT.Application.Feature.Commands.Authentication.Register
{
    public class UserRegisterCommand : IRequest<RegisterResult>
    {
        public string PrivateNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirht { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
