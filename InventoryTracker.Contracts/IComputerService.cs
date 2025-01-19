using InventoryTracker.Contracts;
using InventoryTracker.Models;

namespace InventoryTracker.Interfaces
{
    public interface IComputerService : IService<Computer>
    {
        Task AssignUserAsync(int computerId, int userId);
        Task ChangeStatusAsync(int computerId, int newStatusId);
    }
}
