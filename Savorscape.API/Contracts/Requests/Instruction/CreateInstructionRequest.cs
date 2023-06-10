using Savorscape.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace Savorscape.API.Contracts.Requests.Instruction
{
    public record CreateInstructionRequest
    {
        [Required]
        [MustBePositiveInteger]
        public int Order { get; init; }
        [Required]
        [MaxLength(InstructionConstraints.DescriptionMaxLength)]
        public required string Description { get; init; }
    }
}
