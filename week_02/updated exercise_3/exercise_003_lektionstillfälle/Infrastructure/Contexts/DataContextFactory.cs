using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\hans\\Desktop\\exercise_003_lektionstillfälle\\Infrastructure\\Contexts\\ProjecSQLite_Database.db");
        
        return new DataContext(optionsBuilder.Options);
    }
}