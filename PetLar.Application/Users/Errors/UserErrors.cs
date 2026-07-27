using PetLar.Application.Common.Results;

namespace PetLar.Application.Users.Errors;

public static class UserErrors
{
    public static readonly Error EmailAlreadyRegistered = 
        new("USER.EMAIL_ALREADY_REGISTERED",
        "Já existe um usuário com este e-mail");
}
