namespace Savorscape.API.Contracts.Responses.Instructions
{
    public record InstructionsResponse(
        int InstructionID,
        int Order,
        string Description,
        int RecipeId
        );
}
