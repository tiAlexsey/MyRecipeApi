using Domain.Abstract.Repository;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Services.Database.Repository;

public class IngredientRepository : IIngredientRepository
{
    private readonly ILogger<IngredientRepository> _logger;
    private readonly DatabaseContext _repository;

    public IngredientRepository(DatabaseContext repository, ILogger<IngredientRepository> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public Ingredient Get(int id) => _repository.Ingredient.FirstOrDefault(x => x.Id == id);
    public IEnumerable<Ingredient> GetList() => _repository.Ingredient;

    public bool Add(Ingredient ingredient = null!)
    {
        try
        {
            _repository.Ingredient.Add(ingredient);
            _repository.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }

    public bool Update(Ingredient ing = null!)
    {
        try
        {
            _repository.Ingredient.Update(ing);
            _repository.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var ingredient = _repository.Ingredient.FirstOrDefault(e => e.Id == id);
            _repository.Ingredient.Remove(ingredient);
            _repository.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }
}