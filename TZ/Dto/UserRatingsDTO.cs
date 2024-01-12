namespace TZ.WebApi.Dto
{
    public record UserRatingsDTO
    (
        long Id,
        string? Review,
        int StarsCount,
        string Product
    );
}
