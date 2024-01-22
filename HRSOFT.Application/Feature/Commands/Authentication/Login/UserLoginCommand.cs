using HRSOFT.Domain.Common;
using MediatR;

namespace HRSOFT.Application.Feature.Commands.Authentication.Login
{
    public class UserLoginCommand : IRequest<LoginResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
