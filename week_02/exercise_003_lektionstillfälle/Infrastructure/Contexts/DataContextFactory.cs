using System.Runtime.InteropServices;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var connectionString = DatabaseHelper.GetDatabaseConnectionString();

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new DataContext(optionsBuilder.Options);
    }
}