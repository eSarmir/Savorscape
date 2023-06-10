using Savorscape.Database.Models;

namespace Savorscape.API.Contracts.Responses.Recipe
{
    public record RecipeResponse(
        int RecipeID,
        string Title,
        string Description,
        int PreparationTime,
        int Difficulty,
        int Servings,
        IEnumerable<Instruction> Instructions
        );
}
