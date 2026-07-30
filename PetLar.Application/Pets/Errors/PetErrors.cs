using PetLar.Application.Common.Results;

namespace PetLar.Application.Pets.Errors;

public static class PetErrors
{
    public static readonly Error OngNotFound =
        new("PET.ONG_NOT_FOUND",
        "ONG não encontrada");

    public static readonly Error UserIsNotOng =
        new("PET.USER_IS_NOT_ONG",
        "O usuário informado não é uma ONG");

    public static readonly Error PetNotFound = 
        new("PET.NOT_FOUND",
        "Pet não encontrado");

    public static readonly Error PetNotOwnedByUser = 
        new("PET.NOT_OWNED_BY_USER",
        "Pet não pertence ao usuário");
}

