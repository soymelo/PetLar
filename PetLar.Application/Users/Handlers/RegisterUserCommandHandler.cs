using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Users.Commands;
using PetLar.Application.Users.Errors;
using PetLar.Core.Entities;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Users.Handlers;

public class RegisterUserCommandHandler(IUserRepository _userRepository) : IRequestHandler<RegisterUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken ct)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, ct);
        if (existingUser is not null)
        {
            return Result<Guid>.Failure(UserErrors.EmailAlreadyRegistered);
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, 11);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            PasswordHash = passwordHash
        };

        await _userRepository.AddAsync(user, ct);

        return Result<Guid>.Success(user.Id);
    }
}
