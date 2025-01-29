using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        string databasePath;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            databasePath = @"C:\Projects\DataBase\SQLite_Database.db";
        }
        else
        {
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Projects", "Database", "SQLite_Database.db");
        }

        string connectionString = $"Data Source={databasePath}";

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new DataContext(optionsBuilder.Options);
    }
}