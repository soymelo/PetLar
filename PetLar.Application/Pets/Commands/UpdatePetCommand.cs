using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Core.Enums;

namespace PetLar.Application.Pets.Commands;

public record UpdatePetCommand(
    Guid Id,
    string Name,
    int Age,
    PetGender Gender,
    PetSpecies Species,
    PetSize Size,
    PetStatus Status,
    Guid OngId
) : IRequest<Result>;
