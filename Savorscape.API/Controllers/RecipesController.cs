using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Savorscape.API.Contracts.Requests.Recipe;
using Savorscape.API.Contracts.Responses.Recipe;
using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.API.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RecipeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var recipe = recipeRepository.GetByID(id);

            if (recipe == null) 
            {
                return NotFound();
            }

            RecipeResponse response = MapRecipeToRecipeResponse(recipe);
            
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RecipeResponse), StatusCodes.Status201Created)]
        public IActionResult Create(CreateRecipeRequest request)
        {
            var recipe = recipeRepository.Create(new Recipe()
            {
                Title = request.Title,
                Description = request.Description,
                PreparationTime = request.PreparationTime,
                Difficulty = request.Difficulty,
                Servings = request.Servings
            });

            recipeRepository.SaveChanges();

            RecipeResponse response = MapRecipeToRecipeResponse(recipe);

            return CreatedAtAction(
                nameof(Get),
                new { Id = response.RecipeID },
                response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(int id, UpdateRecipeRequest request) 
        {
            recipeRepository.Update(new Recipe()
            {
                RecipeID = id,
                Title = request.Title,
                Description = request.Description,
                PreparationTime = request.PreparationTime,
                Difficulty = request.Difficulty,
                Servings = request.Servings
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var wasDeleted = recipeRepository.Delete(id);

            if (wasDeleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        private static RecipeResponse MapRecipeToRecipeResponse(Recipe recipe)
        {
            return new RecipeResponse(
                            recipe.RecipeID,
                            recipe.Title,
                            recipe.Description,
                            recipe.PreparationTime,
                            recipe.Difficulty,
                            recipe.Servings);
        }
    }
}
