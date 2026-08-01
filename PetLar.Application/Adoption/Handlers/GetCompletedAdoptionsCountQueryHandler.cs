using MediatR;
using PetLar.Application.Adoption.Queries;
using PetLar.Application.Common.Results;
using PetLar.Core.Enums;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Adoption.Handlers;

public class GetCompletedAdoptionsCountQueryHandler(IAdoptionRepository _adoptionRepository) : IRequestHandler<GetCompletedAdoptionsCountQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetCompletedAdoptionsCountQuery _, CancellationToken ct)
    {
        var adoptionsCount = await _adoptionRepository.CountByStatusAsync(AdoptionStatus.Completed, ct);

        return Result<int>.Success(adoptionsCount);
    }
}
