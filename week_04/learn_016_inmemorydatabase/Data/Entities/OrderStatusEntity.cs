using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class OrderStatusEntity
{
    [Key]
    public int Id { get; set; }
    public string Status { get; set; } = null!;
}