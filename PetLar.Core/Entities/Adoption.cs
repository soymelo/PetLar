using PetLar.Core.Enums;

namespace PetLar.Core.Entities;

public class Adoption
{
    public Guid Id { get; set; }
    public AdoptionStatus Status { get; set; }
    public string? Message { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public DateTime? RejectedAt { get; set; }

    public Guid PetId { get; set; }
    public Pet Pet { get; set; } = null!;

    public Guid AdopterId { get; set; }
    public User Adopter { get; set; } = null!;
}
