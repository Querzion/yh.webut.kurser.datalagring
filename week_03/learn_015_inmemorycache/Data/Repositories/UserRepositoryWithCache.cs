using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Data.Repositories;

public class UserRepositoryWithCache(DataContext context, IMemoryCache cache) : IUserRepositoryWithCache
{
    private readonly DataContext _context = context;
    private readonly IMemoryCache _cache = cache;
    
    private string GetCacheKey(string methodName, object? key = null) =>
    $"UserRepositoryWithCache_{methodName}_{key ?? "all"}";
    
    public async Task AddAsync(UserEntity entity)
    {
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        
        // Remove the CacheKey upon changes.
        _cache.Remove(GetCacheKey(nameof(GetAllAsync)));
    }

    // Query key becomes: 
    // "UserRepositoryWithCache_GetAllAsync_all"
    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        // Create a cache variable
        var cacheKey = GetCacheKey(nameof(GetAllAsync));
        // Initiate the Cache variable based on the UserEntity IEnumerable list.
        if (_cache.TryGetValue(cacheKey, out IEnumerable<UserEntity>? cachedEntities))
        {
            return cachedEntities!;
        }
        
        var entities = await _context.Users.ToListAsync();
        
        // Set the limit to how long you want the cache to be available (recommendation is about 5-10 min) (set to 5 min)
        _cache.Set(cacheKey, entities, TimeSpan.FromMinutes(5));
        
        return entities;
    }

    // Query key becomes: 
    // x => x.Id == id    "UserRepositoryWithCache_GetAsync_x => x.Id == id"
    public async Task<UserEntity?> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        var cacheKey = GetCacheKey(nameof(GetAsync), predicate.ToString());
        if (_cache.TryGetValue(cacheKey, out UserEntity? cachedEntity))
        {
            return cachedEntity!;
        }
        
        var entity = await _context.Users.FirstOrDefaultAsync(predicate);
        _cache.Set(cacheKey, entity, TimeSpan.FromMinutes(2));
        
        return entity;
    }
}