using HRSOFT.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace HRSOFT.Application.Feature.Commands.Authentication.Register
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, RegisterResult>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserRegisterCommandHandler(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<RegisterResult> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var findByEmail = await _userManager.FindByEmailAsync(request.Email);

            if (findByEmail != null)
            {
                return new RegisterResult()
                {
                    Success = false
                };
            }

            // Define the regex pattern
            string pattern = @"^(.*?)@";

            // Create a regex object
            Regex regex = new Regex(pattern);

            // Match the pattern against the email
            Match match = regex.Match(request.Email);

            string userName = match.Groups[1].Value;

            var newUser = User.Create(request.PrivateNumber, request.Name, userName, request.LastName, request.DateOfBirht, request.Email, request.Password, request.RepeatPassword);
            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, isPersistent: false);
            }

            return new RegisterResult()
            {
                Success = true
            };
        }
    }
}
