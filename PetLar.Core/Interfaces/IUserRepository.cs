using PetLar.Core.Entities;

namespace PetLar.Core.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken ct);
    Task<User?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<User?> GetByEmailAsync(string email, CancellationToken ct);
    Task<int> GetOngsCountAsync(CancellationToken ct);
}
