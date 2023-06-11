using FluentResults;
using Savorscape.Database.Models;

namespace Savorscape.API.Services.IService
{
    public interface IRecipeService
    {
        Result<Recipe> GetFullRecipeByID(int id);
        Result<Recipe> CreateRecipe(Recipe recipe);
        Result<bool> UpdateRecipe(Recipe recipe);
        Result<bool> DeleteRecipe(int id);
    }
}
