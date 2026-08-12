using PetLar.Core.Enums;

namespace PetLar.Web.Extensions;

public static class EnumDisplayExtensions
{
    public static string ToDisplayName(this PetGender gender) =>
    gender switch
    {
        PetGender.Male => "Macho",
        PetGender.Female => "Fêmea",
        _ => gender.ToString()
    };

    public static string ToDisplayName(this PetSpecies species) =>
    species switch
    {
        PetSpecies.Dog => "Cachorro",
        PetSpecies.Cat => "Gato",
        _ => species.ToString()
    };

    public static string ToDisplayName(this PetSize size) =>
    size switch
    {
        PetSize.Small => "Pequeno",
        PetSize.Medium => "Médio",
        PetSize.Large => "Grande",
        _ => size.ToString()
    };
}
