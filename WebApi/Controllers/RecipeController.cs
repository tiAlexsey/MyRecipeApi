using Domain.Abstract.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Model;
using WebApi.Utils;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeRepository _repository;

    public RecipeController(IRecipeRepository repository)
    {
        _repository = repository;
    }

    [SwaggerOperation(Summary = "Get a recipe by id")]
    [HttpGet("{idDish}")]
    public CommonResponse Get(int idDish)
    {
        var response = _repository.Get(idDish);
        return response != null
            ? new CommonResponse(response)
            : new CommonResponse("Recipe is not found");
    }

    [SwaggerOperation(Summary = "Add a ingredient to recipe")]
    [HttpPost("AddIngredient")]
    public CommonResponse AddIngredient(int idDish, int idIngredient, bool isRequired)
    {
        return new CommonResponse(Function.Response(_repository.AddIngredient(idDish, idIngredient, isRequired)));
    }

    [SwaggerOperation(Summary = "Remove a ingredient from recipe")]
    [HttpPost("RemoveIngredient")]
    public CommonResponse RemoveIngredient(int idDish, int idIngredient)
    {
        return new CommonResponse(Function.Response(_repository.RemoveIngredient(idDish, idIngredient)));
    }
}