using MediatR;
using PetLar.Application.Common.Results;

namespace PetLar.Application.Users.Commands;

public record RegisterUserCommand(
    string Name,
    string Email,
    string Password
) : IRequest<Result<Guid>>;
