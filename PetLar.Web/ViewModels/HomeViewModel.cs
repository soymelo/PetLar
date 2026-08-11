using PetLar.Application.Pets.DTOs;

namespace PetLar.Web.ViewModels;

public class HomeViewModel
{
    public IReadOnlyList<PetDto> AvailablePets { get; set; } = [];
    public int AvailablePetsCount { get; set; }
    public int OngsCount { get; set; }
    public int CompletedAdoptionsCount { get; set; }
}
