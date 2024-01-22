using HRSOFT.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRSOFT.Application.Feature.Commands.Authentication.Logout
{
    public class UserLogoutCommandHandler : IRequestHandler<UserLogoutCommand>
    {
        private readonly SignInManager<User> _signInManager;

        public UserLogoutCommandHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task Handle(UserLogoutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
        }
    }
}
