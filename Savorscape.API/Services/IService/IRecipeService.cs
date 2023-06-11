using FluentResults;
using Savorscape.Database.Models;

namespace Savorscape.API.Services.IService
{
    public interface IRecipeService
    {
        Result<Recipe> GetFullRecipeByID(int id);
        Result<Recipe> CreateRecipe(Recipe toCreate);
        Result<bool> UpdateRecipe(Recipe toUpdate);
        Result<bool> DeleteRecipe(int id);
    }
}
