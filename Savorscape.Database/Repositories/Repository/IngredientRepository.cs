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
            return entities
                .Where(i => i.RecipeId == recipeId);
        }

        public Ingredient? GetRecipeIngredient(int recipeId, int ingredientId)
        {
            return entities
                .SingleOrDefault(i => i.RecipeId == recipeId && i.IngredientID == ingredientId);
        }

        public bool DeleteRecipeIngredient(int recipeId, int id)
        {
            var entity = GetRecipeIngredient(recipeId, id);

            if (entity == null)
                return false;

            Delete(entity);

            return true;
        }
    }
}
