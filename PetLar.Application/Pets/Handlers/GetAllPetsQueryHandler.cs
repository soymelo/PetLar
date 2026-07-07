using MediatR;
using PetLar.Application.Pets.Queries;
using PetLar.Application.Pets.DTOs;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class GetAllPetsQueryHandler(IPetRepository _petRepository) : IRequestHandler<GetAllPetsQuery, IEnumerable<PetDto>>
{
    public async Task<IEnumerable<PetDto>> Handle(GetAllPetsQuery request, CancellationToken ct)
    {
        var pets = await _petRepository.GetAllPetsAsync(ct);

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
