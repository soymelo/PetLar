using Microsoft.EntityFrameworkCore;
using PetLar.Core.Enums;
using PetLar.Core.Interfaces;
using PetLar.Infrastructure.Data;

namespace PetLar.Infrastructure.Repositories;

public class AdoptionRepository(PetLarDbContext _context) : IAdoptionRepository
{
    public Task<int> CountByStatusAsync(AdoptionStatus status, CancellationToken ct)
    {
        return _context.Adoptions.CountAsync(adoption => adoption.Status == status, ct);
    }
}
