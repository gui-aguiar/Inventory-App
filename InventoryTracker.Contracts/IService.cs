namespace InventoryTracker.Contracts
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(int offset, int limit);
        Task<T?> GetByIdAsync(int id);
    }
}
