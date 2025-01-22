namespace InventoryTracker.Models
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public PaginationMetadata Pagination { get; set; }
    }
}
