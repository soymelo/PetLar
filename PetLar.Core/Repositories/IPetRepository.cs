using PetLar.Core.Entities;

namespace PetLar.Core.Repositories;

public interface IPetRepository
{
    Task AddAsync(Pet pet);
    Task<Pet?> GetByIdAsync(Guid id);
    Task<IEnumerable<Pet>> GetAllPetsAsync();
    Task UpdateAsync(Pet pet);
    Task<IEnumerable<Pet>> GetByOwnerIdAsync(Guid ownerId);
}