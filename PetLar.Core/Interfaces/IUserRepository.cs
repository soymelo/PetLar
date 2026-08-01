using PetLar.Core.Entities;
using PetLar.Core.Enums;

namespace PetLar.Core.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken ct);
    Task<User?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<User?> GetByEmailAsync(string email, CancellationToken ct);
    Task<int> CountByTypeAsync(UserType type, CancellationToken ct);
}
