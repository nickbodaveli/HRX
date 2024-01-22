using HRSOFT.Application.Feature.Commands.Employee.Create;
using HRSOFT.Application.Feature.Commands.Employee.Delete;
using HRSOFT.Application.Feature.Commands.Employee.Edit;
using HRSOFT.Application.Feature.Queries.Employee;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRSOFT.API.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ISender _mediator;

        public EmployeeController(ISender mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult>Index()
        {
            var query = new GetEmployeesQuery();

            var employees = await _mediator.Send(query);
            return View(employees);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var query = new GetEmployeeQuery()
            {
                Id = id
            };

            var employee = await _mediator.Send(query);
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            var mediator = await _mediator.Send(command);

            if(!mediator)
            {
                TempData["ErrorMessage"] = "Employee has already exist!";
                return View();
            }

            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetEmployeeQuery()
            {
                Id = id
            };

            var employee = await _mediator.Send(query);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, EmployeeUpdateCommand command)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please fill fields!";

                return RedirectToAction("Index", "Employee");
            }

            if (id != command.Id)
            {
                TempData["ErrorMessage"] = "Update is permitted!";
                return View();
            }

            var mediator = await _mediator.Send(command);

            if(!mediator)
            {
                TempData["ErrorMessage"] = "Update is permitted!";
                return View();
            }

            return RedirectToAction("Index", "Employee");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = new EmployeeDeleteCommand()
            {
                Id = id
            };

            var mediator = await _mediator.Send(employee);    

            if(!mediator)
            {
                TempData["ErrorMessage"] = "Here was problem during Delete employee";
                return View();
            }

            return RedirectToAction("Index", "Employee");
        }
    }
}
