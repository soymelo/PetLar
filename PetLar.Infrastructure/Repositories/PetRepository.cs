using Microsoft.EntityFrameworkCore;
using PetLar.Core.Entities;
using PetLar.Core.Enums;
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
        return await _context.Pets.Include(p => p.Ong).FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<IEnumerable<Pet>> GetAllPetsAsync(CancellationToken ct)
    {
        return await _context.Pets.Include(p => p.Ong).ToListAsync(ct);
    }

    public async Task UpdateAsync(Pet pet, CancellationToken ct)
    {
        _context.Pets.Update(pet);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Pet>> GetByOngIdAsync(Guid ongId, CancellationToken ct)
    {
        return await _context.Pets.Where(p => p.OngId == ongId).Include(p => p.Ong).ToListAsync(ct);
    }

    public async Task<IEnumerable<Pet>> GetAvailablePetsAsync(CancellationToken ct)
    {
        return await _context.Pets
            .AsNoTracking()
            .Where(p => p.Status == EnumPetStatus.Available)
            .ToListAsync(ct);
    }

}
