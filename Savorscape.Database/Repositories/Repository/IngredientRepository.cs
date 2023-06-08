using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.Database.Repositories.Repository
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(SavorscapeDbContext context) : base(context)
        {
        }

        public IEnumerable<Ingredient> GetAllRecipeIngredients(int recipeId)
        {
            return context.Ingredients
                .Where(i => i.RecipeId == recipeId);
        }
    }
}
