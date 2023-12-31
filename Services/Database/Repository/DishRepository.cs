using Domain.Abstract.Repository;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Services.Database.Repository;

public class DishRepository : IDishRepository
{
    private readonly ILogger<DishRepository> _logger;
    private readonly DatabaseContext _repository;

    public DishRepository(DatabaseContext repository, ILogger<DishRepository> logger)
    {
        _logger = logger;
        _repository = repository;
    }

    public Dish Get(int id) => _repository.Dish.FirstOrDefault(x => x.Id == id);
    public IEnumerable<Dish> GetList() => _repository.Dish;

    public bool Add(Dish dish = null!)
    {
        try
        {
            _repository.Dish.Add(dish);
            _repository.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }

    public bool Update(Dish dish = null!)
    {
        try
        {
            _repository.Dish.Update(dish);
            _repository.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }

    public bool Delete(int idDish)
    {
        try
        {
            var dish = Get(idDish);
            _repository.Dish.Remove(dish);
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