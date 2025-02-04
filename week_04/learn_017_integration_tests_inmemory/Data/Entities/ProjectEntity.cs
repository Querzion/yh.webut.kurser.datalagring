using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; }
    
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}