using PetLar.Core.Entities;
using PetLar.Core.Enums;

namespace PetLar.Core.Interfaces;

public interface IPetRepository
{
    Task AddAsync(Pet pet, CancellationToken ct);
    Task<Pet?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IEnumerable<Pet>> GetAllPetsAsync(CancellationToken ct);
    Task<IEnumerable<Pet>> GetAvailablePetsAsync(int limit, CancellationToken ct);
    Task<int> CountByStatusAsync(PetStatus status, CancellationToken ct);
    Task UpdateAsync(Pet pet, CancellationToken ct);
    Task<IEnumerable<Pet>> GetByOngIdAsync(Guid ongId, CancellationToken ct);
}
