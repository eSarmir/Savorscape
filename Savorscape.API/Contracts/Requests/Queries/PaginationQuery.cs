using Savorscape.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace Savorscape.API.Contracts.Requests.Queries
{
    public record PaginationQuery
    {
        [Required]
        [MustBePositiveInteger]
        public int PageNumber { get; init; }
        [Required]
        [MustBePositiveInteger]
        public int PageSize { get; init; }
    }
}
