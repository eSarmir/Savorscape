namespace Savorscape.API.Contracts.Responses.Instructions
{
    public record InstructionResponse(
        int InstructionID,
        int Order,
        string Description,
        int RecipeId
        );
}
