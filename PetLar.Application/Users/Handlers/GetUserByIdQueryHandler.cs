using MediatR;
using PetLar.Application.Users.Queries;
using PetLar.Application.Users.ViewModels;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Users.Handlers;

public class GetUserByIdQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetUserByIdQuery, UserViewModel?>
{
    public async Task<UserViewModel?> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user is null)
            return null;

        return new UserViewModel(
            user.Id,
            user.Name,
            user.Email,
            user.Type
        );
    }
}
