using MediatR;
using PetLar.Application.Pets.Queries;
using PetLar.Application.Pets.DTOs;
using PetLar.Core.Interfaces;
using PetLar.Application.Common.Results;

namespace PetLar.Application.Pets.Handlers;

public class GetAllPetsQueryHandler(IPetRepository _petRepository) : IRequestHandler<GetAllPetsQuery, Result<IEnumerable<PetDto>>>
{
    public async Task<Result<IEnumerable<PetDto>>> Handle(GetAllPetsQuery _, CancellationToken ct)
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
            p.OngId
        )).ToList();

        return Result<IEnumerable<PetDto>>.Success(petsDto);
    }
}
