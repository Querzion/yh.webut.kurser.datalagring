using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Data.Helpers;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var connectionString = DatabaseHelper.GetSQLServerDatabaseConnectionString();

var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer(connectionString))
    .AddScoped<IRoleRepository, RoleRepository>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IUserService, UserService>();
    
var serviceProvider = services.BuildServiceProvider();
var userService = serviceProvider.GetRequiredService<IUserService>();

var userRegistrationForm = new UserRegistrationForm()
{
    FirstName = "Slisk",
    LastName = "Lindqvist",
    Email = "slisk.lindqvist@querzion.com",
    Password = "BytMig123!",
    ConfirmPassword = "BytMig123!"
};


var result = await userService.CreateUserAsync(userRegistrationForm);

switch (result.StatusCode)
{
    case 200:
        Console.WriteLine("User created successfully.");
        break;
    
    case 400:
        Console.WriteLine($"{result.ErrorMessage}");
        break;

    case 409:
        Console.WriteLine($"{result.ErrorMessage}");
        break;
    
    case 500:
        Console.WriteLine($"{result.ErrorMessage}");
        break;
}

Console.ReadKey();