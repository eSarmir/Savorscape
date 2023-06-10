namespace Savorscape.API.Contracts.Requests.Instruction
{
    public record CreateInstructionRequest(
        int Order,
        string Description
        );
}
