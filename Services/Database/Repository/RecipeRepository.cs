using Domain.Abstract.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Services.Database.Repository;

public class RecipeRepository : IRecipeRepository
{
    private readonly ILogger<RecipeRepository> _logger;
    private readonly DatabaseContext _repository;

    public RecipeRepository(DatabaseContext repository, ILogger<RecipeRepository> logger)
    {
        _logger = logger;
        _repository = repository;
    }

    public Recipe Get(int idDish)
    {
        var recipe = _repository.LinkIngredients
            .Where(x => x.Dish.Id == idDish)
            .Include("Dish")
            .Include("Ingredient")
            .ToList();

        return recipe.Count > 0 ? new Recipe(recipe) : null;
    }

    public bool AddIngredient(int idDish, int idIngredient, bool isRequired)
    {
        try
        {
            var newIngr = new LinkIngredients()
            {
                IdDish = idDish,
                IdIngredient = idIngredient,
                IsRequired = isRequired
            };
            _repository.LinkIngredients.Add(newIngr);
            _repository.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogInformation(e.Message);
            return false;
        }
    }

    public bool RemoveIngredient(int idDish, int idIngredient)
    {
        try
        {
            var li = _repository.LinkIngredients
                .FirstOrDefault(e => e.IdDish == idDish && e.IdIngredient == idIngredient);

            _repository.LinkIngredients.Remove(li);
            _repository.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            _logger.LogInformation(e.Message);
            return false;
        }
    }
}