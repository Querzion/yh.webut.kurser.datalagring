using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite("Data Source=/home/querzion/RiderProjects/yh.webut.kurser.datalagring/week_02/learn_010_generics_and_abstract/Data/Databases/SQLite_Database.db");
        
        return new DataContext(optionsBuilder.Options);
    }
}