using Microsoft.EntityFrameworkCore;
using TZ.Data;
using TZ.Shared;
using TZ.Shared.Enums;
using TZ.Shared.Extensions;
using TZ.WebApi.Dto;
using TZ.WebApi.Services.Interfaces;

namespace TZ.WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly TZContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger, TZContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PagedList<ProductRatingsDTO>> GetProductRatingsWithPagingAsync(long productId, PagingOptions pagingOptions, SortOrder sortOrder)
        {
            _logger.LogInformation("Get product ratings with paging. " +
                "Product id = {productId}. Page = {page}. PageSize = {pageSize}", productId, pagingOptions.PageNumber, pagingOptions.PageSize);

            return await _context.Ratings
                .Where(r => r.ProductId == productId)
                .Select(r => new ProductRatingsDTO
                {
                    RatingId = r.Id, 
                    Review = r.Review, 
                    StarsCount = r.StarsCount,
                    UserName = r.User.Name 
                })
                .OrderByDynamic("StarsCount", sortOrder)
                .AsNoTracking()
                .PagingAsync(pagingOptions);
        }

        public async Task<PagedList<AverageProductsRatingDTO>> GetAverageProductsRatingWithPagingAsync(PagingOptions pagingOptions, SortOrder sortOrder)
        {
            _logger.LogInformation("Get average product rating with paging. " +
                "Page = {page}. PageSize = {pageSize}", pagingOptions.PageNumber, pagingOptions.PageSize);

            return await _context.Products
                .Where(p => p.Ratings.Any())
                 .Select(p => new AverageProductsRatingDTO
                 {
                     ProductId = p.Id,
                     ProductName = p.Name,
                     AverageRating = p.Ratings.Select(r => r.StarsCount).Average()
                 })
                .OrderByDynamic("AverageRating", sortOrder)
                .AsNoTracking()
                .PagingAsync(pagingOptions);
        }
    }
}
