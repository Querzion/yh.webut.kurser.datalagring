namespace Data.Entities;

public class RoleEntity
{
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;
    
    public virtual ICollection<UserEntity> Users { get; set; } = [];
}