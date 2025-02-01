using Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var connectionString = DatabaseHelper.GetSQLServerDatabaseConnectionString();
        
        var optionsbuilder = new DbContextOptionsBuilder<DataContext>();
        optionsbuilder.UseSqlServer(connectionString);
        return new DataContext(optionsbuilder.Options);
    }
}