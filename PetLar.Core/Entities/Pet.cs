using PetLar.Core.Enums;

namespace PetLar.Core.Entities;

public class Pet
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public PetGender Gender { get; set; }
    public PetSpecies Species { get; set; }
    public PetSize Size { get; set; }
    public PetStatus Status { get; set; }

    public Guid OngId { get; set; }
    public User Ong { get; set; } = null!;
}
