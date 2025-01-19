using InventoryTracker.Models;

namespace InventoryTracker.Contracts
{
    public interface IComputerUserService
    {
        Task<User> GetUserOrThrowAsync(int userId);
        void AssignNewUser(Computer computer, User user);
    }
}
