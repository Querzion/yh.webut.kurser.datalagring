using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    
    [Column(TypeName = "NVARCHAR(450)")]
    public string CustomerName { get; set; } = null!;
    
    public DateTime OrderDate { get; set; }
    public DateTime DueDate { get; set; }
    
    public virtual ICollection<OrderRowEntity> OrderRows { get; set; } = [];
}