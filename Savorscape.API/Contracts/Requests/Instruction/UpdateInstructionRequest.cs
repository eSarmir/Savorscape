using Savorscape.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace Savorscape.API.Contracts.Requests.Instruction
{
    public record UpdateInstructionRequest
    {
        [Required]
        public int InstructionID { get; init; }
        [Required]
        [MustBePositiveInteger]
        public int Order { get; init; }
        [Required]
        [MaxLength(InstructionConstraints.DescriptionMaxLength)]
        public required string Description { get; init; }
        [Required]
        public int RecipeID { get; init; }
    }
}
