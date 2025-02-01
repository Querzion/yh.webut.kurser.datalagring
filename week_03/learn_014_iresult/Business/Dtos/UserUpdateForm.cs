using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class UserUpdateForm
{
    // First name with validation
    // [Required(ErrorMessage = "First name is required")]
    // [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    [Required]
    public string FirstName { get; set; } = null!;

    // Last name with validation
    // [Required(ErrorMessage = "Last name is required")]
    // [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    [Required]
    public string LastName { get; set; } = null!;
}