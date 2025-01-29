using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Index(nameof(Email), IsUnique = true)]
public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string? PhoneNumber { get; set; }
}