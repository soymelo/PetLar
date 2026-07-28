using PetLar.Application.Common.Results;

namespace PetLar.Application.Pets.Errors;

public static class PetErrors
{
    public static readonly Error PetNotFound = 
        new("PET.NOT_FOUND",
        "Pet não encontrado");

    public static readonly Error PetNotOwnedByUser = 
        new("PET.NOT_OWNED_BY_USER",
        "Pet não pertence ao usuário");
}
