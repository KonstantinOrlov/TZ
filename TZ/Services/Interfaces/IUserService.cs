using TZ.WebApi.Dto;

namespace TZ.WebApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserRatingsDTO>> GetUserRatingsAsync(long userId);
    }
}
