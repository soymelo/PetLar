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
    public async Task<IActionResult> Register(RegisterUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var command = new RegisterUserCommand(
            model.Name,
            model.Email,
            model.Password);

        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            ModelState.AddModelError(nameof(model.Email), result.Error.Message);
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }
}
