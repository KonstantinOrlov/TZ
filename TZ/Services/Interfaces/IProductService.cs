using TZ.Shared;
using TZ.Shared.Enums;
using TZ.WebApi.Dto;

namespace TZ.WebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<PagedList<ProductRatingsDTO>> GetProductRatingsWithPaging(long id, PagingOptions pagingOptions, SortOrder sortOrder);
        Task<PagedList<AverageProductsRatingDTO>> GetAverageProductsRatingWithPaging(PagingOptions pagingOptions, SortOrder sortOrder);
    }
}
