using Savorscape.Database.Models;

namespace Savorscape.API.Services
{
    public interface IRecipeService
    {
        Recipe? GetRecipe(int id);
        void CreateRecipe(string title);
    }
}
