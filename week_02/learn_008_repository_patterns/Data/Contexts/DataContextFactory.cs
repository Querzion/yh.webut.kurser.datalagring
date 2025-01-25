using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    // private readonly string _connectionString = @"
    //     Server=localhost;
    //     Database=sql_database;
    //     Trusted_Connection=False;
    //     Persist Security Info=False;
    //     Encrypt=False;
    //     User ID=Querzion;
    //     Password=Scam2014;
    //     Connect Timeout=30;
    // ";
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite("Data Source=/home/querzion/RiderProjects/yh.webut.kurser.datalagring/week_02/learn_008_repository_patterns/Data/Databases/SQLiteDatabase.db");
        // optionsBuilder.UseSqlServer(@"Server=localhost;Database=sql_database;Trusted_Connection=False;Persist Security Info=False;Encrypt=False;User ID=Querzion;Password=Scam2014;Connect Timeout=30;");
        
        return new DataContext(optionsBuilder.Options);
    }
}