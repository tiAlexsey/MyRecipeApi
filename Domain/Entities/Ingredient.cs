using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Ingredient", Schema = "ctl")]
public class Ingredient
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Img { get; set; }
}