using Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
}