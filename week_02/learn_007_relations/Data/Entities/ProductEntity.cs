using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}