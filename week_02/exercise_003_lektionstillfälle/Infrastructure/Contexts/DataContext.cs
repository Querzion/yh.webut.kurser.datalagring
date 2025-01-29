using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options) 
{
    public DbSet<CustomerEntity> Customer { get; set; } = null!;
}