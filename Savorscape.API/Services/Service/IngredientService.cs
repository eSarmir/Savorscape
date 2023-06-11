using FluentResults;
using Savorscape.API.Services.IService;
using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.API.Services.Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public Result<IEnumerable<Ingredient>> GetAllRecipeIngredients(int recipeId)
        {
            return Result.Ok(ingredientRepository.GetAllRecipeIngredients(recipeId));
        }

        public Result<Ingredient> GetRecipeIngredient(int recipeId, int ingredientId)
        {
            var ingredient = ingredientRepository.GetRecipeIngredient(recipeId, ingredientId);

            if (ingredient == null) 
            {
                return Result.Fail($"The ingredient with ID {ingredientId} in recipe with ID {recipeId} was not found!");
            }

            return ingredient;
        }

        public Result<Ingredient> CreateRecipeIngredient(Ingredient toCreate)
        {
            var ingredient = ingredientRepository.Create(toCreate);

            ingredientRepository.SaveChanges();

            return ingredient;
        }

        public Result<bool> UpdateRecipeIngredient(Ingredient toUpdate)
        {
            var ingredient = ingredientRepository.GetRecipeIngredient(toUpdate.RecipeId, toUpdate.IngredientID);

            if (ingredient == null)
            {
                return Result.Fail($"The ingredient with ID {toUpdate.IngredientID} in recipe with ID {toUpdate.RecipeId} was not found!");
            }

            return true;
        }

        public Result<bool> DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            var wasDeleted = ingredientRepository.DeleteRecipeIngredient(recipeId, ingredientId);
            
            if (wasDeleted == false)
            {
                return Result.Fail($"The ingredient with ID {ingredientId} in recipe with ID {recipeId} was not found!");
            }

            return true;
        }
    }
}
