using Microsoft.EntityFrameworkCore;
using PetLar.Core.Entities;
using PetLar.Core.Interfaces;
using PetLar.Infrastructure.Data;

namespace PetLar.Infrastructure.Repositories;

public class PetRepository(PetLarDbContext _context) : IPetRepository
{
    public async Task AddAsync(Pet pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
    }

    public async Task<Pet?> GetByIdAsync(Guid id)
    {
        return await _context.Pets.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Pet>> GetAllPetsAsync()
    {
        return await _context.Pets.Include(p => p.Owner).ToListAsync();
    }

    public async Task UpdateAsync(Pet pet)
    {
        _context.Pets.Update(pet);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Pet>> GetByOwnerIdAsync(Guid ownerId)
    {
        return await _context.Pets.Where(p => p.OwnerId == ownerId).Include(o => o.Owner).ToListAsync();
    }
}
