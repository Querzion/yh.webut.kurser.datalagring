namespace Data.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Password { get; set; }
    public string? SecurityKey { get; set; }
    
    public int RoleId { get; set; }
    public virtual RoleEntity Role { get; set; } = null!;
}