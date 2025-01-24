using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    // Collection in order to get all Products from the Category
    public ICollection<ProductEntity> Products { get; set; } = [];
}