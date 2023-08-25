using Domain.Entities;

namespace Domain.Abstract.Repository;

public interface IRecipeRepository
{
    public Recipe Get(int id);
    public bool AddIngredient(int idDish, int idIngredient, bool isRequired);
    public bool RemoveIngredient(int idDish, int idIngredient);
}