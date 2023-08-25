using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("linkingredients", Schema = "ctl")]
public class LinkIngredients
{
    [Key] 
    public int Id { get; set; }
    public int IdDish { get; set; }
    public int IdIngredient { get; set; }

    [ForeignKey("IdDish")] 
    public Dish Dish { get; set; } = null!;

    [ForeignKey("IdIngredient")] 
    public Ingredient Ingredient { get; set; } = null!;
    public bool IsRequired { get; set; }
}