using Microsoft.AspNetCore.Mvc;
using TZ.WebApi.Services.Interfaces;
using TZ.WebApi.Dto;

namespace TZ.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRating(RatingDTO ratingDTO)
        {
            await _ratingService.CreateRatingAsync(ratingDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRating(UpdateRatingDTO ratingDTO)
        {
            await _ratingService.UpdateRatingAsync(ratingDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(long id)
        {
            await _ratingService.DeleteRatingAsync(id);
            return Ok();
        }
    }
}
