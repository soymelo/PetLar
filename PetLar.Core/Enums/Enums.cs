namespace PetLar.Core.Enums;

public enum UserType { Adopter, Ong }

public enum PetGender { Male, Female }

public enum PetSpecies { Dog, Cat }

public enum PetSize { Small, Medium, Large }

public enum PetStatus
{
    Available = 0,
    Reserved = 1,
    Adopted = 2
}

public enum AdoptionStatus
{
    Pending = 0,
    Approved = 1,
    Completed = 2,
    Rejected = 3,
    Cancelled = 4
}
