using Business.Services;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation_Console.Dialogs;

var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=/home/querzion/RiderProjects/yh.webut.kurser.datalagring/week_02/learn_006_entity_framework_core/Presentation.Avalonia/Data/Databases/users.db"));
serviceCollection.AddScoped<IUserService, UserService>();
serviceCollection.AddScoped<IMenuDialogs, MenuDialogs>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var menuDialogs = serviceProvider.GetRequiredService<IMenuDialogs>();

while (true)
{
    menuDialogs.NewUserDialog();
    menuDialogs.ViewAllUsersDialog();
}