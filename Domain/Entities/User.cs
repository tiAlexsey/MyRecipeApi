using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("User", Schema = "ctl")]
public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
}