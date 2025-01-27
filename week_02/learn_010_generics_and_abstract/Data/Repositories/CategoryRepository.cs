using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CategoryRepository(DataContext context) : BaseRepository<CategoryEntity>(context), ICategoryRepository
{
    private readonly DataContext _context = context;
}