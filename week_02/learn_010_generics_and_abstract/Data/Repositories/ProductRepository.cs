using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

// public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context), IProductRepository
public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context)
{
    private readonly DataContext _context = context;
    
    // public async Task<IEnumerable<ProductEntity>> GetAllWithCategoryAsync()
    // {
    //     var entities = await _context.Products.Include(x => x.Category).ToListAsync();
    //     return entities!;
    // }
}