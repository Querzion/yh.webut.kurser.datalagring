using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeExpression = null)
    {
        // Create a searchable list, by creating an empty variable and set it to the database
        IQueryable<TEntity> query = _dbSet;
        
        // And if it's not empty include the expression in the list. (make a list out of a list, that is now searchable.)
        if (includeExpression != null)
            query = includeExpression(query);
        
        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeExpression = null)
    {
        IQueryable<TEntity> query = _dbSet;
        
        if (includeExpression != null)
            query = includeExpression(query);
        
        return await query.FirstOrDefaultAsync(predicate);
    }
}

