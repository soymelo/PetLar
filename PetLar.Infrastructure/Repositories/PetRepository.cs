using Microsoft.EntityFrameworkCore;
using PetLar.Core.Entities;
using PetLar.Core.Interfaces;
using PetLar.Infrastructure.Data;

namespace PetLar.Infrastructure.Repositories;

public class PetRepository(PetLarDbContext _context) : IPetRepository
{
    public async Task AddAsync(Pet pet, CancellationToken ct)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<Pet?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Pets.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<IEnumerable<Pet>> GetAllPetsAsync(CancellationToken ct)
    {
        return await _context.Pets.Include(p => p.Owner).ToListAsync(ct);
    }

    public async Task UpdateAsync(Pet pet, CancellationToken ct)
    {
        _context.Pets.Update(pet);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Pet>> GetByOwnerIdAsync(Guid ownerId, CancellationToken ct)
    {
        return await _context.Pets.Where(p => p.OwnerId == ownerId).Include(p => p.Owner).ToListAsync(ct);
    }
}
