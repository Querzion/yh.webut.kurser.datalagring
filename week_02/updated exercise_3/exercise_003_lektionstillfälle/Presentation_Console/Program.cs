using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation_Console.Dialogs;

var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlite("Data Source=C:\\Users\\hans\\Desktop\\exercise_003_lektionstillfälle\\Infrastructure\\Contexts\\ProjecSQLite_Database.db"))
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<CustomerDialogs>()
    .BuildServiceProvider();

    var customerDialogs = services.GetRequiredService<CustomerDialogs>();
    await customerDialogs.MenuOptions();