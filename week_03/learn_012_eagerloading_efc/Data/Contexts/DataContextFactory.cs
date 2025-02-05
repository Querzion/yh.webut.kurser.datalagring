using Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        // var connectionString = DatabaseHelper.GetSQLiteDatabaseConnectionString();
        var connectionString = DatabaseHelper.GetSQLServerDatabaseConnectionString();
        
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        // optionsBuilder.UseSqlite(connectionString);
        optionsBuilder.UseSqlServer(connectionString);
        
        return new DataContext(optionsBuilder.Options);
    }
}