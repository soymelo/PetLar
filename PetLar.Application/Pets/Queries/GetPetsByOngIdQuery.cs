using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Pets.DTOs;

namespace PetLar.Application.Pets.Queries;

public record GetPetsByOngIdQuery(
    Guid OngId
) : IRequest<Result<IEnumerable<PetDto>>>;
