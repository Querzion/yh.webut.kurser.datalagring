using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UnitEntity> Units { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderRowEntity> OrderRows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Specify the Primary key (Combined Key in this case)
        modelBuilder.Entity<OrderRowEntity>()
            .HasKey(x => new { x.Id, x.OrderId });
        
        // Specify relation connections
        modelBuilder.Entity<OrderRowEntity>()
            .HasOne(x => x.Order)
            .WithMany(order => order.OrderRows)
            .HasForeignKey(row => row.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.OnModelCreating(modelBuilder);
    }
}