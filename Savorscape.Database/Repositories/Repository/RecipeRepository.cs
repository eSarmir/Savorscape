using Microsoft.EntityFrameworkCore;
using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.Database.Repositories.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(SavorscapeDbContext context) : base(context)
        {
        }

        public Recipe? GetFullRecipeByID(int id)
        {
            return entities
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .FirstOrDefault(r => r.RecipeID == id);
        }

        public IEnumerable<Recipe> GetPaginatedRecipes(int skip, int take)
        {
            return entities
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .OrderBy(r => r.RecipeID)
                .Skip(skip)
                .Take(take);
        }
    }
}
