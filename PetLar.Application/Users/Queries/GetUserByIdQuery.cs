using MediatR;
using PetLar.Application.Users.DTOs;

namespace PetLar.Application.Users.Queries;

public record GetUserByIdQuery(
    Guid Id
) : IRequest<UserDto?>;
