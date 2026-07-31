using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Core.Enums;

namespace PetLar.Application.Pets.Commands;

public record RegisterPetCommand(
    string Name,
    int Age,
    PetGender Gender,
    PetSpecies Species,
    PetSize Size,
    Guid OngId
) : IRequest<Result<Guid>>;
