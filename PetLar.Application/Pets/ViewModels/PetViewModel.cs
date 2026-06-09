using PetLar.Core.Enums;

namespace PetLar.Application.Pets.ViewModels;

public record PetViewModel(
    Guid Id,
    string Name,
    int Age,
    EnumGender Gender,
    EnumSpecies Species,
    EnumSize Size,
    EnumPetStatus Status,
    Guid OwnerId
    );