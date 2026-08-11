using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Pets.Queries;
using PetLar.Core.Enums;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class GetAvailablePetsCountQueryHandler(IPetRepository _petRepository) : IRequestHandler<GetAvailablePetsCountQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetAvailablePetsCountQuery _, CancellationToken ct)
    {
        var petsCount = await _petRepository.CountByStatusAsync(PetStatus.Available, ct);

        return Result<int>.Success(petsCount);
    }
}
