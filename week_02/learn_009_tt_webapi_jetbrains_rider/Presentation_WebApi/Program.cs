using Business.Contexts;
using Business.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddScoped<UserService>();

var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();