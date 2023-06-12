using FluentResults;
using Savorscape.API.Services.IService;
using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.API.Services.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public Result<Recipe> GetFullRecipeByID(int id)
        {
            var recipe = recipeRepository.GetFullRecipeByID(id);

            if (recipe is null)
            {
                return Result.Fail(GetRecipeNotFoundErrorMessage(id));
            }

            return recipe;
        }

        public Result<Recipe> CreateRecipe(Recipe toCreate)
        {
            Recipe createdRecipe = recipeRepository.Create(toCreate);

            recipeRepository.SaveChanges();

            return createdRecipe;
        }

        public Result<bool> UpdateRecipe(Recipe toUpdate)
        {
            var recipe = recipeRepository.GetByID(toUpdate.RecipeID);

            if (recipe is null)
            {
                return Result.Fail(GetRecipeNotFoundErrorMessage(toUpdate.RecipeID));
            }
               
            recipeRepository.Update(toUpdate);

            recipeRepository.SaveChanges();

            return true;
        }

        public Result<bool> DeleteRecipe(int id)
        {
            bool wasDeleted = recipeRepository.Delete(id);

            if (wasDeleted is false)
            {
                return Result.Fail(GetRecipeNotFoundErrorMessage(id));
            }

            recipeRepository.SaveChanges();

            return true;
        }

        private static string GetRecipeNotFoundErrorMessage(int id)
        {
            return $"The recipe with ID {id} was not found!";
        }
    }
}
