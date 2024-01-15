using Microsoft.EntityFrameworkCore;
using TZ.Data;
using TZ.WebApi.Dto;
using TZ.WebApi.Services.Interfaces;

namespace TZ.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly TZContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger, TZContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<UserRatingsDTO>> GetUserRatingsAsync(long userId)
        {
            _logger.LogInformation("Get user ratings. User Id :{userId}", userId);

            return await _context.Ratings
                .Where(r => r.UserId == userId)
                .Select(r => new UserRatingsDTO(r.Id, r.Review, r.StarsCount, r.Product.Name))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
