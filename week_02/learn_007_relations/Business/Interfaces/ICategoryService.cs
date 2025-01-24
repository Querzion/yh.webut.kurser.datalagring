using Data.Entities;

namespace Business.Services;

public interface ICategoryService
{
    CategoryEntity CreateCategory(string categoryName);
    CategoryEntity GetCategoryByName(string categoryName);
}