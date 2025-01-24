using Data.Contexts;
using Data.Entities;

namespace Business.Services;

public class CategoryService(DataContext context) : ICategoryService
{
    private readonly DataContext _context = context;

    public CategoryEntity CreateCategory(string categoryName)
    {
        var categoryEntity = GetCategoryByName(categoryName);
        if (categoryEntity == null)
        {
            categoryEntity!.Name = categoryName;
            _context.Categories.Add(categoryEntity);
            _context.SaveChanges();
        }
        
        return categoryEntity;
    }

    public CategoryEntity GetCategoryByName(string categoryName)
    {
        var categoryEntity = _context.Categories.FirstOrDefault(c => c.Name == categoryName);
        return categoryEntity ?? null!;
    }
}