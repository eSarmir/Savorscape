using Savorscape.Database.Models;

namespace Savorscape.Database.Repositories
{
    public interface IRecipeRepository
    {
        Recipe? GetRecipe(int id);
        void CreateRecipe(string title);
    }
}
