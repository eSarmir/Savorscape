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

            if (recipe == null) 
            {
                return Result.Fail($"The recipe with ID {id} was not found!");
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

            if (recipe == null)
            {
                return Result.Fail($"The recipe with ID {toUpdate.RecipeID} was not found!");
            }
               
            recipeRepository.Update(toUpdate);

            recipeRepository.SaveChanges();

            return true;
        }

        public Result<bool> DeleteRecipe(int id)
        {
            bool wasDeleted = recipeRepository.Delete(id);

            if (!wasDeleted)
            {
                return Result.Fail($"The recipe with ID {id} was not found!");
            }

            recipeRepository.SaveChanges();

            return true;
        }
    }
}
