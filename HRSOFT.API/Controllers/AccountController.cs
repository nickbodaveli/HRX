using HRSOFT.Application.Common.Interfaces;
using HRSOFT.Application.Feature.Commands.Authentication.Login;
using HRSOFT.Application.Feature.Commands.Authentication.Logout;
using HRSOFT.Application.Feature.Commands.Authentication.Register;
using HRSOFT.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRSOFT.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISender _mediator;

        public AccountController(ISender mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            
            var mediator = await _mediator.Send(command);

            if(!mediator.Success)
            {
                TempData["ErrorMessage"] = "User have already exist.";
                return RedirectToAction("Login");
            }

            return RedirectToAction("Index", "Employee");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            var authenticatedUser = await _mediator.Send(command);
            if(authenticatedUser.Success)
            {
                return RedirectToAction("Index", "Employee");
            }

            TempData["ErrorMessage"] = "Username or password is incorrect.";

            return View();
        }

        public async Task<IActionResult> Logout(UserLogoutCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Login", "Account");
        }
    }
}
