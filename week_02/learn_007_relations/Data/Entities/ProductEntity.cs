using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    
    // Get the respective category that's linked to a product.
    public int CategoryId { get; set; }
    
    // [JsonIgnore]
    public CategoryEntity Category { get; set; } = null!;
}