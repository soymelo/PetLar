using PetLar.Core.Enums;

namespace PetLar.Core.Interfaces;

public interface IAdoptionRepository
{
    Task<int> CountByStatusAsync(AdoptionStatus status, CancellationToken ct);
}
