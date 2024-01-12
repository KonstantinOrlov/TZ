namespace TZ.WebApi.Dto
{
    public record ProductRatingsDTO
    {
        public long RatingId { get; init; }
        public string? Review { get; init; }
        public int StarsCount { get; init; }
        public string UserName { get; init; }
    }
}
