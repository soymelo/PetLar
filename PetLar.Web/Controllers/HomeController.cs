using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetLar.Application.Pets.Queries;
using PetLar.Application.Users.Queries;
using PetLar.Web.Models;
using PetLar.Web.ViewModels;
using System.Diagnostics;

namespace PetLar.Web.Controllers
{
    public class HomeController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var petsResult = await _mediator.Send(new GetAvailablePetsQuery(), ct);
            var ongsCountResult = await _mediator.Send(new GetOngsCountQuery(), ct);

            if (petsResult.IsFailure || ongsCountResult.IsFailure)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = HttpContext.TraceIdentifier
                });
            }

            var model = new HomeViewModel
            {
                AvailablePets = petsResult.Value?.ToList() ?? [],
                OngsCount = ongsCountResult.Value
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
