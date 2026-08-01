using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Users.Queries;
using PetLar.Core.Enums;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Users.Handlers;

public class GetOngsCountQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetOngsCountQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetOngsCountQuery _, CancellationToken ct)
    {
        var ongsCount = await _userRepository.CountByTypeAsync(UserType.Ong, ct);

        return Result<int>.Success(ongsCount);
    }
}
