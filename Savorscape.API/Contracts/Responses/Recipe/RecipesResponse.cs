namespace Savorscape.API.Contracts.Responses.Recipe
{
    public record RecipesResponse (
        int PageNumber,
        int PageSize,
        IEnumerable<RecipeResponse> Recipes
        );
}
