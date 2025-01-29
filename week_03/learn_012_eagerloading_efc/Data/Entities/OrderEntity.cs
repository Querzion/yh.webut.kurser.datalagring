using Microsoft.VisualBasic;

namespace Data.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public DateTime DueDate { get; set; }
    
    // public ICollection<OrderRowEntity> OrderRows { get; set; } = new List<OrderRowEntity>();
    // It's just a newer way of writing the row above.
    public ICollection<OrderRowEntity> OrderRows { get; set; } = [];
}