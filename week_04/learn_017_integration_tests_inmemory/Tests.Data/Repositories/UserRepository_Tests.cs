using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.Data.Repositories;

public class UserRepository_Tests
{
    private readonly DataContext _context;
    private readonly UserRepository _userRepository;

    public UserRepository_Tests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .UseLazyLoadingProxies()
            .Options;
        
        _context = new DataContext(options);
        _userRepository = new UserRepository(_context);
    }
}