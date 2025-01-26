using InventoryTracker.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InventoryTracker.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(int offset, int limit)
        {
            return await _repository.GetAll()
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
