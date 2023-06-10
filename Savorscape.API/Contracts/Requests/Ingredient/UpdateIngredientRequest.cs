namespace Savorscape.API.Contracts.Requests.Ingredient
{
    public record UpdateIngredientRequest (
        string Name,
        int Quantity,
        string Unit,
        int RecipeId
        );
}
