using TZ.Shared;
using TZ.Shared.Enums;
using TZ.WebApi.Dto;

namespace TZ.WebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<PagedList<ProductRatingsDTO>> GetProductRatingsWithPagingAsync(long id, PagingOptions pagingOptions, SortOrder sortOrder);
        Task<PagedList<AverageProductsRatingDTO>> GetAverageProductsRatingWithPagingAsync(PagingOptions pagingOptions, SortOrder sortOrder);
    }
}
