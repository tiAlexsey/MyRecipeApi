using Domain.Entities;

namespace Domain.Abstract.Repository;

public interface IDishRepository
{
    public Dish Get(int id);
    public List<Dish> GetList();
    public bool Add(Dish dish);
    public bool Update(Dish dish);
    public bool Delete(int id);
}