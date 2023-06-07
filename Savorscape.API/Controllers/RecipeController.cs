using Microsoft.AspNetCore.Mvc;
using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipeController(IRecipeRepository recipeService)
        {
            this.recipeRepository = recipeService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = recipeRepository.GetByID(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(string title)
        {
            recipeRepository.Create(new Recipe() { Title = title, Description = "" });

            return Ok();
        }
    }
}
