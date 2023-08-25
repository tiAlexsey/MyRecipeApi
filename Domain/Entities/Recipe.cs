namespace Domain.Entities;

public class Recipe
{
    public Dish Dish { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<Ingredient> OptionalIngredients { get; set; }

    public Recipe(List<LinkIngredients> li)
    {
        Dish = li.FirstOrDefault().Dish;
        var ingredients = new List<Ingredient>();
        var optionalIngredients = new List<Ingredient>();
        foreach (var e in li)
        {
            if (e.IsRequired)
            {
                ingredients.Add(e.Ingredient);
            }
            else
            {
                optionalIngredients.Add(e.Ingredient);
            }
        }

        Ingredients = ingredients;
        OptionalIngredients = optionalIngredients;
    }
}