using MediatR;
using PetLar.Application.Pets.Queries;
using PetLar.Application.Pets.ViewModels;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class GetAllPetsQueryHandler(IPetRepository _petRepository) : IRequestHandler<GetAllPetsQuery, IEnumerable<PetViewModel>>
{
    public async Task<IEnumerable<PetViewModel>> Handle(GetAllPetsQuery request, CancellationToken ct)
    {
        var pets = await _petRepository.GetAllPetsAsync();

        var petViewModel = pets.Select(p => new PetViewModel(
            p.Id,
            p.Name,
            p.Age,
            p.Gender,
            p.Species,
            p.Size,
            p.Status,
            p.OwnerId
        )).ToList();

        return petViewModel;
    }
}
