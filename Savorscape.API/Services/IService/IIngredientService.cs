using FluentResults;
using Savorscape.Database.Models;

namespace Savorscape.API.Services.IService
{
    public interface IIngredientService
    {
        Result<IEnumerable<Ingredient>> GetAllRecipeIngredients(int recipeId);
        Result<Ingredient> GetRecipeIngredient(int recipeId, int ingredientId);
        Result<Ingredient> CreateRecipeIngredient(Ingredient toCreate);
        Result<bool> UpdateRecipeIngredient(Ingredient toUpdate);
        Result<bool> DeleteRecipeIngredient(int recipeId, int ingredientId);
    }
}
