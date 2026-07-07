using MediatR;
using PetLar.Application.Users.Commands;
using PetLar.Core.Entities;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Users.Handlers;

public class RegisterUserCommandHandler(IUserRepository _userRepository)
                                        : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken ct)
    {
        await ValidationAsync(request, ct);

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, 11);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            PasswordHash = passwordHash
        };

        await _userRepository.AddAsync(user, ct);

        return user.Id;
    }

    private async Task ValidationAsync(RegisterUserCommand request, CancellationToken ct)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, ct);
        if (existingUser != null)
        {
            throw new InvalidOperationException("Este e-mail já está cadastrado.");
        }
    }
}