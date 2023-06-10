namespace Savorscape.Database.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public required string Unit { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
