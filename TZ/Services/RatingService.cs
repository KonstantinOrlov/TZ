using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TZ.Data;
using TZ.Data.Models;
using TZ.WebApi.Dto;
using TZ.WebApi.Services.Interfaces;

namespace TZ.WebApi.Services
{
    public class RatingService : IRatingService
    {
        private readonly TZContext _context;
        private readonly ILogger<RatingService> _logger;
        private readonly IMapper _mapper;

        public RatingService(ILogger<RatingService> logger, IMapper mapper, TZContext context)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateRatingAsync(RatingDTO ratingDTO)
        {
            _logger.LogInformation("create new rating: {rating}", ratingDTO.ToString());

            if (_context.Ratings.Any(r => r.UserId == ratingDTO.UserId && r.ProductId == ratingDTO.ProductId)) throw new Exception("Already exists");

            var rating = _mapper.Map<Rating>(ratingDTO);
            _context.Ratings.Add(rating);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRatingAsync(UpdateRatingDTO ratingDTO)
        {
            _logger.LogInformation("update rating with id = {id}", ratingDTO.Id);

            var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.Id == ratingDTO.Id) ?? throw new Exception($"rating with Id = {ratingDTO} not found");

            _mapper.Map(ratingDTO, rating);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRatingAsync(long id)
        {
            _logger.LogInformation("delete rating with id: {id}", id);

            if (!_context.Ratings.Any(r => r.Id == id)) throw new Exception($"rating with Id = {id} not found");

            await _context.Ratings.Where(r => r.Id == id).ExecuteDeleteAsync();
        }
    }
}
