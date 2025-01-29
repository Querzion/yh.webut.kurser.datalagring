using System.Runtime.InteropServices;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation_Console.Dialogs;
using Presentation_Console.Interfaces;

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

var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlite(connectionString))
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<ICustomerDialogs, CustomerDialogs>()
    .BuildServiceProvider();

var customerDialogs = services.GetRequiredService<ICustomerDialogs>();
await customerDialogs.MenuOptions();