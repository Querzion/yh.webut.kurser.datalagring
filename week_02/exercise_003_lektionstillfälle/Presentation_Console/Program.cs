using System.Runtime.InteropServices;
using Infrastructure.Contexts;
using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation_Console.Dialogs;
using Presentation_Console.Interfaces;

string connectionString = DatabaseHelper.GetDatabaseConnectionString();

var services = new ServiceCollection()
    .AddScoped<DatabaseHelper>()
    .AddDbContext<DataContext>(x => x.UseSqlite(connectionString))
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<ICustomerDialogs, CustomerDialogs>()
    .BuildServiceProvider();

var customerDialogs = services.GetRequiredService<ICustomerDialogs>();
await customerDialogs.MenuOptions();