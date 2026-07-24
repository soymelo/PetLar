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

        try
        {
            await _mediator.Send(command);

            return RedirectToAction("Index", "Home");
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(model);
        }
    }
}

