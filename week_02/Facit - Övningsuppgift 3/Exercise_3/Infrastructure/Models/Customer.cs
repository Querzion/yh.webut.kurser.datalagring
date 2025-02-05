namespace Infrastructure.Models;

public record Customer(int Id, string FirstName, string LastName, string Email, string? PhoneNumber);