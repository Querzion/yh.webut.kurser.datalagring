using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class CustomerRegistrationForm
{
    [Required]
    public string CustomerName { get; set; } = null!;
}