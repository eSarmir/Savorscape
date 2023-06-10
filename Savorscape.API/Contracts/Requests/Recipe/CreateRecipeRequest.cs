using Savorscape.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace Savorscape.API.Contracts.Requests.Recipe
{
    public record CreateRecipeRequest
    {
        [Required]
        [MaxLength(RecipeConstraints.TitleMaxLength)]
        public required string Title { get; init; }
        [Required]
        [MaxLength(RecipeConstraints.DescriptionMaxLength)]
        public required string Description { get; init; }
        [Required]
        [MustBePositiveInteger]
        public int PreparationTime { get; init; }
        [Required]
        [MustBePositiveInteger]
        public int Difficulty { get; init; }
        [Required]
        [MustBePositiveInteger]
        public int Servings { get; init; }
    }
}
