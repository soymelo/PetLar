using PetLar.Core.Entities;

namespace PetLar.Core.Interfaces;

public interface IPetRepository
{
    Task AddAsync(Pet pet, CancellationToken ct);
    Task<Pet?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IEnumerable<Pet>> GetAllPetsAsync(CancellationToken ct);
    Task UpdateAsync(Pet pet, CancellationToken ct);
    Task<IEnumerable<Pet>> GetByOngIdAsync(Guid ongId, CancellationToken ct);
}
