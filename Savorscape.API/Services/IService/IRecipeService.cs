using FluentResults;
using Savorscape.API.Contracts.Requests.Queries;
using Savorscape.API.Contracts.Responses.Recipe;
using Savorscape.Database.Models;

namespace Savorscape.API.Services.IService
{
    public interface IRecipeService
    {
        Result<Recipe> GetFullRecipeByID(int id);
        Result<IEnumerable<Recipe>> GetPaginatedRecipes(PaginationQuery paginationQuery);
        Result<Recipe> CreateRecipe(Recipe toCreate);
        Result<bool> UpdateRecipe(Recipe toUpdate);
        Result<bool> DeleteRecipe(int id);
    }
}
