using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetLar.Application.Users.Commands;
using PetLar.Web.ViewModels;

namespace PetLar.Web.Controllers;

public class UserController(IMediator _mediator) : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        var command = new RegisterUserCommand(
            vm.Name,
            vm.Email,
            vm.Password);

        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            ModelState.AddModelError(nameof(vm.Email), result.Error.Message);
            return View(vm);
        }

        return RedirectToAction("Index", "Home");
    }
}
