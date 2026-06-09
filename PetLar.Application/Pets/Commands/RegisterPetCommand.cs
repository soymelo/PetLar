using MediatR;
using PetLar.Core.Enums;

namespace PetLar.Application.Pets.Commands;

public record RegisterPetCommand(
    string Name,
    int Age,
    EnumGender Gender,
    EnumSpecies Species,
    EnumSize Size,
    Guid OwnerId
) : IRequest<Guid>;
