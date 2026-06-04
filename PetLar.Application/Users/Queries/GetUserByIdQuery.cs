using MediatR;
using PetLar.Application.Users.ViewModels;

namespace PetLar.Application.Users.Queries;

public record GetUserByIdQuery(
    Guid Id
) : IRequest<UserViewModel?>;
