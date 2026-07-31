using PetLar.Core.Enums;

namespace PetLar.Application.Pets.DTOs;

public record PetDto(
    Guid Id,
    string Name,
    int Age,
    PetGender Gender,
    PetSpecies Species,
    PetSize Size,
    PetStatus Status,
    Guid OngId
    );
