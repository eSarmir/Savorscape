using Savorscape.API.Contracts.Responses.Ingredient;
using Savorscape.API.Contracts.Responses.Instructions;

namespace Savorscape.API.Contracts.Responses.Recipe
{
    public record RecipeResponse(
        int RecipeID,
        string Title,
        string Description,
        int PreparationTime,
        int Difficulty,
        int Servings,
        IEnumerable<IngredientResponse> Ingredients,
        IEnumerable<InstructionResponse> Instructions
        );
}
