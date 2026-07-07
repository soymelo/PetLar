using PetLar.Core.Enums;

namespace PetLar.Application.Users.DTOs;

public record UserDto(
    Guid Id,
    string Name,
    string Email,
    EnumType Type
);
