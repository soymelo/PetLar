using Microsoft.EntityFrameworkCore;
using PetLar.Core.Entities;
using PetLar.Core.Interfaces;
using PetLar.Infrastructure.Data;

namespace PetLar.Infrastructure.Repositories;

public class UserRepository(PetLarDbContext _context) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}