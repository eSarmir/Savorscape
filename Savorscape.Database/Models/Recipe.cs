namespace Savorscape.Database.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int PreparationTime { get; set; }
        public int Difficulty { get; set; }
        public int Servings { get; set; }
        public required IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
