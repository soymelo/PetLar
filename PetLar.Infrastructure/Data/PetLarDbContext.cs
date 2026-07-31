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
    public DbSet<Adoption> Adoptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Adoption>(entity =>
        {
            entity.HasKey(adoption => adoption.Id);

            entity.Property(adoption => adoption.Message)
                  .HasMaxLength(1000);

            entity.HasIndex(adoption => adoption.PetId);
            entity.HasIndex(adoption => adoption.AdopterId);

            entity.HasOne(adoption => adoption.Pet)
                  .WithMany()
                  .HasForeignKey(adoption => adoption.PetId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(adoption => adoption.Adopter)
                  .WithMany()
                  .HasForeignKey(adoption => adoption.AdopterId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
