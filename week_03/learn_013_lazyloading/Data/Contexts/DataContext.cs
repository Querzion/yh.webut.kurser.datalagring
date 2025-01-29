using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UnitEntity> Units { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderRowEntity> OrderRows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderRowEntity>()
            .HasKey(x => new { x.Id, x.OrderId });
        
        modelBuilder.Entity<OrderRowEntity>()
            .HasOne(row => row.Order)
            .WithMany(row => row.OrderRows)
            .HasForeignKey(row => row.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.OnModelCreating(modelBuilder);
    }
}