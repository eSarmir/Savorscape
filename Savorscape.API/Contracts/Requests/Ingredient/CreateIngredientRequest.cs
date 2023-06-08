namespace Savorscape.API.Contracts.Requests.Ingredient
{
    public record CreateIngredientRequest (
        string Name,
        int Quantity,
        string Unit
        );
}
