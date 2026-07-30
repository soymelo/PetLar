using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Pets.DTOs;
using PetLar.Application.Pets.Queries;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class GetAvailablePetsQueryHandler(IPetRepository _petRepository) : IRequestHandler<GetAvailablePetsQuery, Result<IEnumerable<PetDto>>>
{
    public async Task<Result<IEnumerable<PetDto>>> Handle(GetAvailablePetsQuery _, CancellationToken ct)
    {
        var pets = await _petRepository.GetAvailablePetsAsync(ct);

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
