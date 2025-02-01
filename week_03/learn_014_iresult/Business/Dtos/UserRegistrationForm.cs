using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class UserRegistrationForm
{
    // First name with validation
    // [Required(ErrorMessage = "First name is required")]
    // [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    [Required] public string FirstName { get; set; } = null!;

    // Last name with validation
    // [Required(ErrorMessage = "Last name is required")]
    // [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    [Required] public string LastName { get; set; } = null!;

    // Email with validation
    // [Required(ErrorMessage = "Email is required")]
    // [EmailAddress(ErrorMessage = "Email must be in a valid format like user@mail.com")]
    [Required] [EmailAddress] public string Email { get; set; } = null!;

    // [Required]
    // [RegularExpression(@"^(?=.*\p{Lu})(?=.*\p{Ll})(?=.*\d)(?=.*[\W_]).{8,}$", 
    // ErrorMessage = "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one numeric character, and one special character.")]
    // [RegularExpression(@"^(?=.*\p{Lu})(?=.*\p{Ll})(?=.*\d)(?=.*[\W_]).{8,}$")] 
    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[a-z])(?=.*\d)(?=.*[@$%*?#&])[A-Za-z\d@$%*?#&]{8,}$")]
    public string Password { get; set; } = null!;
    
    // [Compare(nameof(Password), ErrorMessage = "The password do not match.")]
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;
}