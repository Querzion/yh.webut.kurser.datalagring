using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

// public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context), IProductRepository
public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context)
{
    private readonly DataContext _context = context;

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var entities = await _context.Products
            .Include(p => p.Category)
            .ToListAsync();
        return entities;
    }

    public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        if (expression == null)
            return null!;
        
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(expression) ?? null!;
        
    }

    // public async Task<IEnumerable<ProductEntity>> GetAllWithCategoryAsync()
    // {
    //     var entities = await _context.Products.Include(x => x.Category).ToListAsync();
    //     return entities!;
    // }
}