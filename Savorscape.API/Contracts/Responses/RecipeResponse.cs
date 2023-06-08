namespace Savorscape.API.Contracts.Responses
{
    public record RecipeResponse(
        int RecipeID,
        string Title,
        string Description,
        int PreparationTime,
        int Difficulty,
        int Servings
        );
}
