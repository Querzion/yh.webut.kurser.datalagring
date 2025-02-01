using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class UserRegistrationForm
{
    // First name with validation
    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    public string FirstName { get; set; } = null!;

    // Last name with validation
    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    public string LastName { get; set; } = null!;

    // Email with validation
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email must be in a valid format like user@mail.com")]
    public string Email { get; set; } = null!;
    
    [Required]
    [RegularExpression(@"^(?=.*\p{Lu})(?=.*\p{Ll})(?=.*\d)(?=.*[\W_]).{8,}$", 
        ErrorMessage = "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one numeric character, and one special character.")]
    public string Password { get; set; } = null!;
    
    [Required]
    [Compare(nameof(Password), ErrorMessage = "The password do not match.")]
    public string ConfirmPassword { get; set; } = null!;
}