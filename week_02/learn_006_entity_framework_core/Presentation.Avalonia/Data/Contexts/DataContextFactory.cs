using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    private readonly string _connectionString = "Data Source=/home/querzion/RiderProjects/yh.webut.kurser.datalagring/week_02/learn_006_entity_framework_core/Presentation.Avalonia/Data/Databases/users.db";
    
    public DataContext CreateDbContext(string[] args)
    {
        
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite(_connectionString);

        return new DataContext(optionsBuilder.Options);
    }
}