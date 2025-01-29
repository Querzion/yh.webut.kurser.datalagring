using Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var cT = DatabaseHelper.GetSQLServerDatabaseConnectionString();
        
        var oB = new DbContextOptionsBuilder<DataContext>();
        oB.UseSqlServer(cT);
        return new DataContext(oB.Options);
    }
}