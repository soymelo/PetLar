using PetLar.Core.Enums;

namespace PetLar.Application.Pets.DTOs;

public record PetDto(
    Guid Id,
    string Name,
    int Age,
    EnumGender Gender,
    EnumSpecies Species,
    EnumSize Size,
    EnumPetStatus Status,
    Guid OngId
    );
