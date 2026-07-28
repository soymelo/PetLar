using MediatR;
using PetLar.Application.Users.Queries;
using PetLar.Application.Users.DTOs;
using PetLar.Core.Interfaces;
using PetLar.Application.Common.Results;
using PetLar.Application.Users.Errors;

namespace PetLar.Application.Users.Handlers;

public class GetUserByIdQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, ct);
        if (user is null)
            return Result<UserDto>.Failure(UserErrors.UserNotFound);

        var userDto = new UserDto(
            user.Id,
            user.Name,
            user.Email,
            user.Type
        );

        return Result<UserDto>.Success(userDto);

    }
}
