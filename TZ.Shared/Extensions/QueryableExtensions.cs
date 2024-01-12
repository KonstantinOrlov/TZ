using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TZ.Shared.Enums;

namespace TZ.Shared.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedList<T>> PagingAsync<T>(this IQueryable<T> query, PagingOptions pagingOptions) where T : class
        {
            var count = query.Count();
            var items = await query.Skip((pagingOptions.PageNumber - 1) * pagingOptions.PageSize).Take(pagingOptions.PageSize).ToListAsync();
            return new PagedList<T>(items, count, pagingOptions.PageNumber, pagingOptions.PageSize);
        }

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string orderByMember, SortOrder order)
        {
            var queryElementTypeParam = Expression.Parameter(typeof(T));
            var memberAccess = Expression.PropertyOrField(queryElementTypeParam, orderByMember);
            var keySelector = Expression.Lambda(memberAccess, queryElementTypeParam);

            var orderBy = Expression.Call(
                typeof(Queryable),
                order == SortOrder.ASC ? "OrderBy" : "OrderByDescending",
                new Type[] { typeof(T), memberAccess.Type },
                query.Expression,
                Expression.Quote(keySelector));
            return query.Provider.CreateQuery<T>(orderBy);
        }
    }


    
}
