using Microsoft.AspNetCore.Mvc;
using TZ.WebApi.Dto;
using TZ.WebApi.Services.Interfaces;

namespace TZ.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}/ratings")]
        public async Task<List<UserRatingsDTO>> GetUserRatingWithPaging(long userId)
        {
            var result = await _userService.GetUserRatingsAsync(userId);

            return result;
        }
    }
}
