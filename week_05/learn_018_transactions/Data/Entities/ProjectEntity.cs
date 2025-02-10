using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "NVARCHAR(1000)")]
    public string Description { get; set; } = null!;
    
    [Column(TypeName = "NVARCHAR(75)")]
    public string? Notes { get; set; }
    
    [Required]
    [Column(TypeName = "NVARCHAR(75)")]
    public string Status { get; set; } = null!;
    
    [Required]
    [Column(TypeName = "NVARCHAR(75)")]
    public string ProjectManager { get; set; } = null!;
    
    [Required]
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; } 
    
    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }
    
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = new();
}