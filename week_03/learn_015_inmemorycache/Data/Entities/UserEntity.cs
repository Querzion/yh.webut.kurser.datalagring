using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;
    [Column(TypeName = "varchar(150)")]
    public string Email { get; set; } = null!;
}