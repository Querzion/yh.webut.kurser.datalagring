using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public ICollection<ProductEntity> Products { get; set; } = [];
}