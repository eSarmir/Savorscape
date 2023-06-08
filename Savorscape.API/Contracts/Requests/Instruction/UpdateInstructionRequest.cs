namespace Savorscape.API.Contracts.Requests.Instruction
{
    public record UpdateInstructionRequest(
        int InstructionID,
        int Order,
        string Description,
        int RecipeID
        );
}
