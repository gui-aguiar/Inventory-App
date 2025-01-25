using InventoryTracker.Models;

namespace InventoryTracker.Helpers
{
    public static class PaginationHelper
    {
        public static PaginationMetadata CalculateMetadata(int totalItems, int pageSize, int currentPage)
        {
            return new PaginationMetadata
            {
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = currentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };
        }

        public static IQueryable<T> ApplyPagination<T>(IQueryable<T> query, int offset, int limit)
        {
            return query.Skip(offset).Take(limit);
        }
    }

}
