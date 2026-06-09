using MediatR;
using PetLar.Application.Pets.Queries;
using PetLar.Application.Pets.ViewModels;
using PetLar.Core.Entities;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class GetPetByIdQueryHandler(IPetRepository _petRepository) : IRequestHandler<GetPetByIdQuery, PetViewModel?>
{
    public async Task<PetViewModel?> Handle(GetPetByIdQuery request, CancellationToken ct)
    {
        var pet = await _petRepository.GetByIdAsync(request.Id);
        if (pet is null)
            return null;

        return new PetViewModel(
            pet.Id,
            pet.Name,
            pet.Age,
            pet.Gender,
            pet.Species,
            pet.Size,
            pet.Status,
            pet.OwnerId
        );
    }
}
