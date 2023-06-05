using Savorscape.Database.Models;
using Savorscape.Database.Repositories;

namespace Savorscape.API.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public Recipe? GetRecipe(int id)
        {
            return recipeRepository.GetRecipe(id);
        }

        public void CreateRecipe(string title)
        {
            recipeRepository.CreateRecipe(title);
        }
    }
}
