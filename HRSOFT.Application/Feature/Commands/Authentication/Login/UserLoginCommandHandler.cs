using HRSOFT.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRSOFT.Application.Feature.Commands.Authentication.Login
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, LoginResult>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserLoginCommandHandler(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginResult> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if(user == null)
                {
                    return new LoginResult()
                    {
                        Success = false,
                    };
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, false);
            }
            catch (Exception ex)
            {
                return new LoginResult()
                {
                    Success = false,
                };
            }

            return new LoginResult()
            {
                Success = true
            };
        }
    }

}
