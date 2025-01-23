using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    // public DbSet<UserAddressEntity> UserAddresses { get; set; }
    
    // These overrides that are made from generating code isn't necessary
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // The database can be initialized here if one wish to do so.
    //     // optionsBuilder.UseSqlite("Data Source=../../../../Data/Databases/Users.db");
    //
    //     // You can configure lazy loading from here.
    //     // optionsBuilder.UseLazyLoadingProxies();
    //     
    //     // You can activate logging from here.
    //     // optionsBuilder.LogTo(Console.WriteLine);
    //
    //     // You can activate sensitive data logging from here,
    //     // should only be used in the development stages!!!  
    //     // optionsBuilder.EnableSensitiveDataLogging();
    //
    //     // You can activate caching, so that the application/site,
    //     // becomes faster over time when it comes to search queries in a database etc. from here.
    //     // optionsBuilder.EnableServiceProviderCaching();
    // }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     // Combined Keys to one Primary Key for UserAddressEntity
    //     // modelBuilder.Entity<UserAddressEntity>().HasKey(x => new { x.UserId, x.AddressId });
    //
    //     // Set the Email for the database to be Unique. (Can be done in the Entity File instead)
    //     // modelBuilder.Entity<UserEntity>()
    //     //     .HasIndex(x => x.Email)
    //     //     .IsUnique();
    // }
}