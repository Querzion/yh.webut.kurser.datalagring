using Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var cS = DatabaseHelper.GetSQLServerDatabaseConnectionString();
        
        var oB = new DbContextOptionsBuilder<DataContext>();
        oB.UseSqlServer(cS);
        return new DataContext(oB.Options);
    }
}