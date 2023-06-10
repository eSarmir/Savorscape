using Savorscape.Database.Models;

namespace Savorscape.Database.Repositories.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Recipe? GetFullRecipeByID(int id);
    }
}
