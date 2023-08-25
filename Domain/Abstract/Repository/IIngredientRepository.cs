using Domain.Entities;

namespace Domain.Abstract.Repository;

public interface IIngredientRepository
{
    public Ingredient Get(int id);
    public List<Ingredient> GetList();
    public bool Add(Ingredient ingredient);
    public bool Update(Ingredient ingredient);
    public bool Delete(int id);
}