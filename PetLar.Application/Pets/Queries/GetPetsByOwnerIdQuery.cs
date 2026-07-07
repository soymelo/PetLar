using MediatR;
using PetLar.Application.Pets.DTOs;

namespace PetLar.Application.Pets.Queries;

public record GetPetsByOwnerIdQuery(
    Guid OwnerId
) : IRequest<IEnumerable<PetDto>>;
