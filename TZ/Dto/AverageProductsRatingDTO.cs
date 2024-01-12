namespace TZ.WebApi.Dto
{
    public record AverageProductsRatingDTO
    {
        public long ProductId { get; init; }
        public string ProductName { get; init; }
        public double AverageRating { get; init; }
    }
}
