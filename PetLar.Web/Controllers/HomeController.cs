using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetLar.Application.Pets.Queries;
using PetLar.Web.Models;
using PetLar.Web.ViewModels;
using System.Diagnostics;

namespace PetLar.Web.Controllers
{
    public class HomeController(IMediator _mediator) : Controller
    {
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAvailablePetsQuery(), ct);

            if (result.IsFailure)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = HttpContext.TraceIdentifier
                });
            }

            var pets = result.Value?.ToList() ?? [];

            var model = new HomeViewModel
            {
                AvailablePets = pets
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
