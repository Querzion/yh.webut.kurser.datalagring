using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite("Data Source=/home/querzion/RiderProjects/yh.webut.kurser.datalagring/week_02/exercise_003_lektionstillfälle/Infrastructure/Contexts/SQLite_Database.db");
        
        return new DataContext(optionsBuilder.Options);
    }
}