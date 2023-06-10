using Savorscape.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace Savorscape.API.Contracts.Requests.Ingredient
{
    public record UpdateIngredientRequest
    {
        [Required]
        [MaxLength(IngredientConstraints.NameMaxLength)]
        public required string Name { get; init; }
        [Required]
        [MustBePositiveInteger]
        public int Quantity { get; init; }
        [Required]
        [MaxLength(IngredientConstraints.UnitMaxLength)]
        public required string Unit { get; init; }
        [Required]
        public int RecipeId { get; init; }
    }
}
