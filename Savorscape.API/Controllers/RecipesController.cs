using Microsoft.AspNetCore.Mvc;
using Savorscape.API.Contracts.Requests.Recipe;
using Savorscape.API.Contracts.Responses;
using Savorscape.API.Contracts.Responses.Recipe;
using Savorscape.API.Extensions;
using Savorscape.API.Services.IService;
using Savorscape.Database.Models;

namespace Savorscape.API.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService recipeService;

        public RecipesController(IRecipeService recipeRepository)
        {
            this.recipeService = recipeRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RecipeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClientErrorResponse), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var result = recipeService.GetFullRecipeByID(id);

            return result
                .MatchToActionResult(
                    recipe => Ok(ResponseMappingHelper.MapRecipeToRecipeResponse(recipe)),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }

        [HttpPost]
        [ProducesResponseType(typeof(RecipeResponse), StatusCodes.Status201Created)]
        public IActionResult Create(CreateRecipeRequest request)
        {
            var result = recipeService.CreateRecipe(new Recipe()
            {
                Title = request.Title,
                Description = request.Description,
                PreparationTime = request.PreparationTime,
                Difficulty = request.Difficulty,
                Servings = request.Servings
            });

            return result
                .MatchToActionResult(
                    recipe => CreatedAtAction(
                        nameof(Get), 
                        new { Id = recipe.RecipeID }, 
                        ResponseMappingHelper.MapRecipeToRecipeResponse(recipe)),
                    err => BadRequest()
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(int id, UpdateRecipeRequest request) 
        {
            var result = recipeService.UpdateRecipe(new Recipe()
            {
                RecipeID = id,
                Title = request.Title,
                Description = request.Description,
                PreparationTime = request.PreparationTime,
                Difficulty = request.Difficulty,
                Servings = request.Servings
            });

            return result
                .MatchToActionResult(
                    wasUpdated => NoContent(),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ClientErrorResponse), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var result = recipeService.DeleteRecipe(id);

            return result
                .MatchToActionResult(
                    wasDeleted => NoContent(),
                    err => NotFound(ResponseMappingHelper.MapStringToClientErrorResponse(err.Message))
                );
        }
    }
}
