using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TZ.Shared;
using TZ.Shared.Enums;
using TZ.WebApi.Dto;
using TZ.WebApi.Services.Interfaces;

namespace TZ.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) 
        { 
            _productService = productService;
        }

        [HttpGet("{productId}/ratings/paging")]
        public async Task<PagedList<ProductRatingsDTO>> GetProductRatingWithPaging([FromQuery] PagingOptions options, long productId, SortOrder sortOrder)
        {
            var result = await _productService.GetProductRatingsWithPaging(productId, options, sortOrder);

            var metadata = new
            {
                result.TotalItemCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            };

            Response.Headers.Add("Pagination", JsonSerializer.Serialize(metadata));

            return result;
        }


        [HttpGet("average-ratings/paging")]
        public async Task<PagedList<AverageProductsRatingDTO>> GetAverageProductsRatingWithPaging(SortOrder sortOrder, [FromQuery] PagingOptions options)
        {
            var result = await _productService.GetAverageProductsRatingWithPaging(options, sortOrder);

            var metadata = new
            {
                result.TotalItemCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            };

            Response.Headers.Add("Pagination", JsonSerializer.Serialize(metadata));

            return result;
        }
    }
}
