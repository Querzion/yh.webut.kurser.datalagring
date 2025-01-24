using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Cascade =? Delete's associated Entities Automagically. 
        // .OnDelete(DeleteBehavior.Cascade);
        
        // Restrict =? Stops associated deletions
        // .OnDelete(DeleteBehavior.Restrict);
        
        // SetNull =? Changes the foreign key to null
        // .OnDelete(DeleteBehavior.SetNull);
        
        // NoAction =? Database handles integrity, nothing is done
        // .OnDelete(DeleteBehavior.NoAction);
        
        // ClientNoAction =? Sets foreign key as null in the application, but not on the database.
        // .OnDelete(DeleteBehavior.ClientNoAction);
    }
}