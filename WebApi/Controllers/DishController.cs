using Domain.Abstract.Repository;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Model;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DishController : ControllerBase
{
    private IDishRepository _repository;

    public DishController(IDishRepository repository)
    {
        _repository = repository;
    }

    [SwaggerOperation(Summary = "Get dish by id")]
    [HttpGet]
    public CommonResponse Get(int id)
    {
        var response = _repository.Get(id);
        return response != null
            ? new CommonResponse(response)
            : new CommonResponse("Dish is not found");
    }

    [SwaggerOperation(Summary = "Get a list of dishes")]
    [HttpGet("List")]
    public CommonResponse List()
    {
        var dishes = _repository.GetList().ToList();
        return new CommonResponse(dishes, dishes.Count);
    }

    [SwaggerOperation(Summary = "Add a new dish")]
    [HttpPost("Add")]
    public CommonResponse Add(Dish dish)
    {
        return new CommonResponse(Function.Response(_repository.Add(dish)));
    }

    [SwaggerOperation(Summary = "Update a dish")]
    [HttpPost("Update")]
    public CommonResponse Update(Dish dish)
    {
        return new CommonResponse(Function.Response(_repository.Update(dish)));
    }

    [SwaggerOperation(Summary = "Delete dish by id")]
    [HttpPost("Delete")]
    public CommonResponse Delete(int idDish)
    {
        return new CommonResponse(Function.Response(_repository.Delete(idDish)));
    }
}