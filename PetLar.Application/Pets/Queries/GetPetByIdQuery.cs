using MediatR;
using PetLar.Application.Pets.DTOs;

namespace PetLar.Application.Pets.Queries;

public record GetPetByIdQuery(
    Guid Id
) : IRequest<PetDto?>;
