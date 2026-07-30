using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Core.Enums;

namespace PetLar.Application.Pets.Commands;

public record UpdatePetCommand(
    Guid Id,
    string Name,
    int Age,
    EnumGender Gender,
    EnumSpecies Species,
    EnumSize Size,
    EnumPetStatus Status,
    Guid OngId
) : IRequest<Result>;
