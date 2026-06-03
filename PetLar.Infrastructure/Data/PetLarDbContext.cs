using Microsoft.EntityFrameworkCore;
using PetLar.Core.Entities;

namespace PetLar.Infrastructure.Data;

public class PetLarDbContext : DbContext
{
    public PetLarDbContext(DbContextOptions<PetLarDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
}
