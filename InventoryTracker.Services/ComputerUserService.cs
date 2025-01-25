using InventoryTracker.Contracts;
using InventoryTracker.Models;
using InventoryTracker.Repositories;

namespace InventoryTracker.Services
{
    public class ComputerUserService : IComputerUserService
    {
        private readonly IRepository<User> _userRepository;

        public ComputerUserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId) ?? throw new KeyNotFoundException($"User with ID '{userId}' not found.");
        }

        public void AssignNewUser(Computer computer, User user)
        {
            computer.Users.Add(new LinkComputerUser
            {
                UserId = user.Id,
                ComputerId = computer.Id,
                AssignStartDate = DateTime.UtcNow
            });
        }
    }
}
