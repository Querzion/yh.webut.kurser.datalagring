using Data.Contexts;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.Data.Repositories;

public class CustomerRepository_Tests
{
    private readonly DataContext _context;
    private readonly CustomerRepository _customerRepository;

    public CustomerRepository_Tests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .UseLazyLoadingProxies()
            .Options;
        
        _context = new DataContext(options);
        _customerRepository = new CustomerRepository(_context);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnCustomerEntityFromDatabase()
    {
        // Arrange
        var entity = new CustomerEntity { CustomerName = "Company Inc." };
        
        // Act
        var result = await _customerRepository.AddAsync(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal(entity.CustomerName, result.CustomerName);
    }
}