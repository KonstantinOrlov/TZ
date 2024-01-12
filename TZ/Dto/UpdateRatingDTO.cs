using System.ComponentModel.DataAnnotations;

namespace TZ.WebApi.Dto
{
    public record UpdateRatingDTO
    (
        [Range(0, 5)]
        int StarsCount,
        int Id,
        string? Review
    );
}
