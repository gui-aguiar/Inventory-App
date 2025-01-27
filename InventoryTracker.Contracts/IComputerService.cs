using InventoryTracker.Dtos;
using InventoryTracker.Models;

namespace InventoryTracker.Interfaces
{
    public interface IComputerService
    {        
        Task<(IEnumerable<ComputerDto> Data, PaginationMetadata Metadata)> GetAllAsync(int offset, int limit);
        Task<ComputerDto> GetByIdAsync(int id);
        Task<ComputerDto> AddAsync(SaveComputerDto computerDto);
        Task UpdateAsync(int id, SaveComputerDto computer);
        Task DeleteAsync(int id);
        Task AssignUserAsync(int computerId, int userId);
        Task UnassignUserAsync(int computerId);
        Task ChangeStatusAsync(int computerId, int newStatusId);
    }
}
