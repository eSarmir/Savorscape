using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Savorscape.API.Services;

namespace Savorscape.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = recipeService.GetRecipe(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(string title)
        {
            recipeService.CreateRecipe(title);

            return Ok();
        }
    }
}
