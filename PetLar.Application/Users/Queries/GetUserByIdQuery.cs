using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Users.DTOs;

namespace PetLar.Application.Users.Queries;

public record GetUserByIdQuery(
    Guid Id
) : IRequest<Result<UserDto>>;
