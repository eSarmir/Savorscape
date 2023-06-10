namespace Savorscape.API.Contracts.Requests.Recipe
{
    public record UpdateRecipeRequest(
        string Title,
        string Description,
        int PreparationTime,
        int Difficulty,
        int Servings);
}
