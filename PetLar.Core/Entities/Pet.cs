using PetLar.Core.Enums;

namespace PetLar.Core.Entities;

public class Pet
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public EnumGender Gender { get; set; }
    public EnumSpecies Species { get; set; }
    public EnumSize Size { get; set; }
    public EnumPetStatus Status { get; set; }

    public Guid OngId { get; set; }
    public User Ong { get; set; } = null!;
}
