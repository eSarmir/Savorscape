namespace Savorscape.API.Contracts.Requests
{
    public record UpdateRecipeRequest(
        string Title,
        string Description,
        int PreparationTime,
        int Difficulty,
        int Servings);
}
