using Microsoft.AspNetCore.Mvc;
using Savorscape.API.Contracts.Requests.Ingredient;
using Savorscape.API.Contracts.Responses;
using Savorscape.API.Contracts.Responses.Ingredient;
using Savorscape.API.Extensions;
using Savorscape.API.Services.IService;
using Savorscape.Database.Models;

namespace Savorscape.API.Controllers
{
    [Route("api/recipes/{recipeId}")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        [HttpGet("ingredients/{id}")]
        [ProducesResponseType(typeof(IngredientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int recipeId, int id)
        {
            var result = ingredientService.GetRecipeIngredient(recipeId, id);

            return result
                .MatchToActionResult(
                    instruction => Ok(ResponseMappingHelper.MapIngredientToIngredientResponse(instruction)),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }

        [HttpGet("ingredients")]
        [ProducesResponseType(typeof(IEnumerable<IngredientResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll(int recipeId)
        {
            var result = ingredientService.GetAllRecipeIngredients(recipeId);

            return result
                .MatchToActionResult(
                    ingredients => Ok(ingredients.Select(ResponseMappingHelper.MapIngredientToIngredientResponse)),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }

        [HttpPost("ingredients")]
        [ProducesResponseType(typeof(IngredientResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(int recipeId, CreateIngredientRequest request)
        {
            var result = ingredientService.CreateRecipeIngredient(new Ingredient()
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit,
                RecipeId = recipeId
            });

            return result
                .MatchToActionResult(
                    ingredient => CreatedAtAction(
                        nameof(Get),
                        new { RecipeId = recipeId, Id = ingredient.IngredientID },
                        ResponseMappingHelper.MapIngredientToIngredientResponse(ingredient)),
                    err => BadRequest()
                );
        }

        [HttpPut("ingredients/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ClientErrorResponse), StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, UpdateIngredientRequest request)
        {
            var result = ingredientService.UpdateRecipeIngredient(new Ingredient()
            {
                IngredientID = id,
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit,
                RecipeId = request.RecipeId
            });

            return result
                .MatchToActionResult(
                    wasUpdated => NoContent(),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }

        [HttpDelete("ingredients/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int recipeId, int id)
        {
            var result = ingredientService.DeleteRecipeIngredient(recipeId, id);

            return result
                .MatchToActionResult(
                    wasDeleted => NoContent(),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }
    }
}
