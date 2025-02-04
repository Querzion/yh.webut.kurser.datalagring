using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.Data.Repositories;

public class ProjectRepository_Tests
{
    private readonly DataContext _context;
    private readonly ProjectRepository _projectRepository;

    public ProjectRepository_Tests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .UseLazyLoadingProxies()
            .Options;
        
        _context = new DataContext(options);
        _projectRepository = new ProjectRepository(_context);
    }
}