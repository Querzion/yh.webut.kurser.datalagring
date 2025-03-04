using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class OrderRowEntity
{
    [Key]
    public int Id { get; set; }
    public int OrderId { get; set; }

    public string Description { get; set; } = null!;
    public decimal Quantity { get; set; }
    public int UnitId { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    
    public OrderEntity Order { get; set; } = null!;
    public UnitEntity Unit { get; set; } = null!;
}
