using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }

    [Required] 
    public string CategoryName { get; set; } = null!;
    
    public virtual ICollection<ProductEntity> Products { get; set; } = [];
}