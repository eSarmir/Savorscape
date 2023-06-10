using Microsoft.AspNetCore.Mvc;
using Savorscape.API.Contracts.Requests.Ingredient;
using Savorscape.API.Contracts.Responses.Ingredient;
using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.API.Controllers
{
    [Route("api/recipes/{recipeId}")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientRepository ingredientRepository;

        public IngredientsController(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        [HttpGet("ingredients/{id}")]
        [ProducesResponseType(typeof(IngredientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int recipeId, int id)
        {
            var ingredient = ingredientRepository.GetRecipeIngredient(recipeId, id);

            if (ingredient == null)
            {
                return NotFound();
            }

            IngredientResponse response = ResponseMappingHelper.MapIngredientToIngredientResponse(ingredient);

            return Ok(response);
        }

        [HttpGet("ingredients")]
        [ProducesResponseType(typeof(IEnumerable<IngredientResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll(int recipeId)
        {
            var ingredients = ingredientRepository.GetAllRecipeIngredients(recipeId);

            if (!ingredients.Any())
            {
                return NotFound();
            }

            IEnumerable<IngredientResponse> response = ingredients.Select(ResponseMappingHelper.MapIngredientToIngredientResponse);

            return Ok(response);
        }

        [HttpPost("ingredients")]
        [ProducesResponseType(typeof(IngredientResponse), StatusCodes.Status201Created)]
        public IActionResult Create(int recipeId, CreateIngredientRequest request)
        {
            var ingredient = ingredientRepository.Create(new Ingredient()
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit,
                RecipeId = recipeId
            });

            ingredientRepository.SaveChanges();

            IngredientResponse response = ResponseMappingHelper.MapIngredientToIngredientResponse(ingredient);

            return CreatedAtAction(
                nameof(Get),
                new { RecipeId = recipeId, Id = response.IngredientID },
                response);
        }

        [HttpPut("ingredients/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(int id, UpdateIngredientRequest request)
        {
            ingredientRepository.Update(new Ingredient()
            {
                IngredientID = id,
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit,
                RecipeId = request.RecipeId
            });

            ingredientRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("ingredients/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int recipeId, int id)
        {
            var wasDeleted = ingredientRepository.DeleteRecipeIngredient(recipeId, id);

            if (wasDeleted == false)
            {
                return NotFound();
            }

            ingredientRepository.SaveChanges();

            return NoContent();
        }
    }
}
