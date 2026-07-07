using MediatR;
using PetLar.Application.Pets.DTOs;
using PetLar.Application.Pets.Queries;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class GetPetsByOwnerIdQueryHandler(IPetRepository _petRepository) : IRequestHandler<GetPetsByOwnerIdQuery, IEnumerable<PetDto>>
{
    public async Task<IEnumerable<PetDto>> Handle(GetPetsByOwnerIdQuery request, CancellationToken ct)
    {
        var pets = await _petRepository.GetByOwnerIdAsync(request.OwnerId);

        var petsDto = pets.Select(p => new PetDto(
            p.Id,
            p.Name,
            p.Age,
            p.Gender,
            p.Species,
            p.Size,
            p.Status,
            p.OwnerId
        )).ToList();

        return petsDto;
    }
}
