using InventoryTracker.Contracts;
using InventoryTracker.Dtos;
using InventoryTracker.Models;

namespace InventoryTracker.Interfaces
{
    public interface IComputerService
    {        
        Task<IEnumerable<ComputerDto>> GetAllAsync(int offset, int limit);
        Task<Computer> GetByIdAsync(int id);
        Task<ComputerDto> GetDtoByIdAsync(int id);
        Task<int> GetTotalCountAsync();
        Task AddAsync(Computer computer);
        Task UpdateAsync(Computer computer);
        Task DeleteAsync(int id);
        Task AssignUserAsync(int computerId, int userId);
        Task ChangeStatusAsync(int computerId, int newStatusId);

    }
}
