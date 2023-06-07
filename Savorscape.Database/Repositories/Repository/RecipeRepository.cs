using Savorscape.Database.Models;
using Savorscape.Database.Repositories.IRepository;

namespace Savorscape.Database.Repositories.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(SavorscapeDbContext context) : base(context)
        {
        }
    }
}
