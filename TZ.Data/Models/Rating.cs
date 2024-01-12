namespace TZ.Data.Models
{
    public class Rating
    {
        public long Id { get; set; }
        public string? Review { get; set; }
        public int StarsCount { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

    }
}
