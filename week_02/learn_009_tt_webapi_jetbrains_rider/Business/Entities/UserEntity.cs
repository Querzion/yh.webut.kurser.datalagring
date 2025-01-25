using System.ComponentModel.DataAnnotations;

namespace Business.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; } = null!;
    
    [Required]
    public string LastName { get; set; } = null!;
    
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}