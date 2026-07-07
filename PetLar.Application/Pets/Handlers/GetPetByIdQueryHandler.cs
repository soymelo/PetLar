using MediatR;
using PetLar.Application.Pets.Queries;
using PetLar.Application.Pets.DTOs;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class GetPetByIdQueryHandler(IPetRepository _petRepository) : IRequestHandler<GetPetByIdQuery, PetDto?>
{
    public async Task<PetDto?> Handle(GetPetByIdQuery request, CancellationToken ct)
    {
        var pet = await _petRepository.GetByIdAsync(request.Id, ct);
        if (pet is null)
            return null;

        return new PetDto(
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
