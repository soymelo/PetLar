namespace PetLar.Application.Users.ViewModels;

public record UserViewModel(
    Guid Id,
    string Name,
    string Email
);
