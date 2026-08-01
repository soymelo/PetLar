using Microsoft.EntityFrameworkCore;
using PetLar.Core.Entities;
using PetLar.Core.Enums;
using PetLar.Core.Interfaces;
using PetLar.Infrastructure.Data;

namespace PetLar.Infrastructure.Repositories;

public class UserRepository(PetLarDbContext _context) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken ct)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, ct);
    }

    public async Task<int> CountByTypeAsync(UserType type, CancellationToken ct)
    {
        return await _context.Users.CountAsync(user => user.Type == type, ct);
    }
}
