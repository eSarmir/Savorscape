using Savorscape.API.Contracts.Responses.Instructions;
using Savorscape.API.Contracts.Responses.Recipe;
using Savorscape.Database.Models;

namespace Savorscape.API
{
    public static class ResponseMappingHelper
    {
        public static RecipeResponse MapRecipeToRecipeResponse(Recipe recipe)
        {
            return new RecipeResponse(
                            recipe.RecipeID,
                            recipe.Title,
                            recipe.Description,
                            recipe.PreparationTime,
                            recipe.Difficulty,
                            recipe.Servings,
                            recipe.Instructions.Select(MapInstructionToInstructionResponse));
        }

        public static InstructionResponse MapInstructionToInstructionResponse(Instruction instruction)
        {
            return new InstructionResponse(
                instruction.InstructionID,
                instruction.Order,
                instruction.Description,
                instruction.RecipeId
                );
        }
    }
}
