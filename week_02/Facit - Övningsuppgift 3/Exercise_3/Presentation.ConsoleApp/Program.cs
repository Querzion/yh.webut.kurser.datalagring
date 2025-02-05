using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation.ConsoleApp.Dialogs;
using Presentation.ConsoleApp.Interfaces;

var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\Exercises\\Exercise_3\\Infrastructure\\Contexts\\database.mdf;Integrated Security=True;Connect Timeout=30"))
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<ICustomerDialogs, CustomerDialogs>()
    .BuildServiceProvider();

var customerDialogs = services.GetRequiredService<ICustomerDialogs>();
await customerDialogs.MenuOptions();