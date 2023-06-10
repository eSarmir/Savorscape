using Savorscape.API.Contracts.Responses.Ingredient;
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
                            recipe.Ingredients.Select(MapIngredientToIngredientResponse),
                            recipe.Instructions.Select(MapInstructionToInstructionResponse));
        }

        public static IngredientResponse MapIngredientToIngredientResponse(Ingredient ingredient)
        {
            return new IngredientResponse(
                ingredient.IngredientID,
                ingredient.Name,
                ingredient.Quantity,
                ingredient.Unit
                );
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
