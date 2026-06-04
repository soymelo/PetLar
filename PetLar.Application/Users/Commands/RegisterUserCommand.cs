using MediatR;

namespace PetLar.Application.Users.Commands;

public record RegisterUserCommand(
    string Name,
    string Email,
    string Password
) : IRequest<Guid>;