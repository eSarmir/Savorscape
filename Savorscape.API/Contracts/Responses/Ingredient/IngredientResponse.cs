namespace Savorscape.API.Contracts.Responses.Ingredient
{
    public record IngredientResponse(
        int IngredientID,
        string Name,
        int Quantity,
        string Unit
        );
}
