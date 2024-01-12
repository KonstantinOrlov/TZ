using TZ.WebApi.Dto;

namespace TZ.WebApi.Services.Interfaces
{
    public interface IRatingService
    {
        Task CreateRatingAsync(RatingDTO ratingDTO);
        Task UpdateRatingAsync(UpdateRatingDTO ratingDTO);
        Task DeleteRatingAsync(long id);
    }
}
