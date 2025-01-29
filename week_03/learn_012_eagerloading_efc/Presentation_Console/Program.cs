using System.Text.Encodings.Web;
using System.Text.Json;
using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Data.Helpers;
using Data.Interfaces;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var connectionString = DatabaseHelper.GetDatabaseConnectionString();

var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlite(connectionString))
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IOrderService, OrderService>();

var serviceProvider = services.BuildServiceProvider();
var orderService = serviceProvider.GetRequiredService<IOrderService>();

var orders = await orderService.GetAllOrdersAsync();

JsonSerializerOptions options = new()
{
    WriteIndented = true,
    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

foreach (var order in orders)
{
    var json = JsonSerializer.Serialize(order, options);
    Console.WriteLine(json);
}

Console.ReadKey();