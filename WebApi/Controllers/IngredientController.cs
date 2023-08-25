using Domain.Abstract.Repository;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Model;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientRepository _repository;

    public IngredientController(IIngredientRepository repository)
    {
        _repository = repository;
    }

    [SwaggerOperation(Summary = "Get ingredient by id")]
    [HttpGet]
    public CommonResponse Get(int id)
    {
        var response = _repository.Get(id);
        return response != null
            ? new CommonResponse(_repository.Get(id))
            : new CommonResponse("Ingredient is not found");
    }

    [SwaggerOperation(Summary = "Get a list of ingredients")]
    [HttpGet("List")]
    public CommonResponse GetList()
    {
        var ings = _repository.GetList();
        return new CommonResponse(ings, ings.Count);
    }

    [SwaggerOperation(Summary = "Add a new ingredient")]
    [HttpPost("Add")]
    public CommonResponse Add(Ingredient ingredient)
    {
        return new CommonResponse(Function.Response(_repository.Add(ingredient)));
    }

    [SwaggerOperation(Summary = "Update ingredient")]
    [HttpPost("Update")]
    public CommonResponse Update(Ingredient ingredient)
    {
        return new CommonResponse(Function.Response(_repository.Update(ingredient)));
    }

    [SwaggerOperation(Summary = "Delete ingredient by id")]
    [HttpPost("Delete")]
    public CommonResponse Delete(int id)
    {
        return new CommonResponse(Function.Response(_repository.Delete(id)));
    }
}