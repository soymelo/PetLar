using MediatR;
using PetLar.Application.Users.Queries;
using PetLar.Application.Users.DTOs;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Users.Handlers;

public class GetUserByIdQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, ct);
        if (user is null)
            return null;

        return new UserDto(
            user.Id,
            user.Name,
            user.Email,
            user.Type
        );
    }
}
