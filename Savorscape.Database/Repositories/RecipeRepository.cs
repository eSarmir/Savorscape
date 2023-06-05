using Savorscape.Database.Models;

namespace Savorscape.Database.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly SavorscapeDbContext dbContext;

        public RecipeRepository(SavorscapeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Recipe? GetRecipe(int id)
        {
            return dbContext.Recipes.Find(id);
        }
        public void CreateRecipe(string title)
        {
            Recipe toAdd = new () { Title = title };

            dbContext.Recipes.Add(toAdd);

            dbContext.SaveChanges();
        }
    }
}
