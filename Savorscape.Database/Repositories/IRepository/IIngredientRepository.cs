using Savorscape.Database.Models;

namespace Savorscape.Database.Repositories.IRepository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        IEnumerable<Ingredient> GetAllRecipeIngredients(int recipeId);
    }
}
