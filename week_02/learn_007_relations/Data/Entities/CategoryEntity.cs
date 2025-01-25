using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    // Collection in order to get all Products from the Category
    // [JsonIgnore]
    public ICollection<ProductEntity> Products { get; set; } = [];
}