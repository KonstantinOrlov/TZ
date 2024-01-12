using System.ComponentModel.DataAnnotations;

namespace TZ.WebApi.Dto
{
    public record RatingDTO
    (
        [Range(0, 5)]
        int StarsCount,
        string? Review,
        long UserId,
        long ProductId
    );
}
