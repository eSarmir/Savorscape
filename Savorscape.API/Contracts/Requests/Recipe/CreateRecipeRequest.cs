namespace Savorscape.API.Contracts.Requests.Recipe
{
    public record CreateRecipeRequest(
        string Title,
        string Description,
        int PreparationTime,
        int Difficulty,
        int Servings);
}
