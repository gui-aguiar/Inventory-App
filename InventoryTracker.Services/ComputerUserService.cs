using InventoryTracker.Contracts;
using InventoryTracker.Models;

namespace InventoryTracker.Services
{
    public class ComputerUserService : IComputerUserService
    {
        private readonly IRepository<User> _userRepository;

        public ComputerUserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserOrThrowAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return user ?? throw new ArgumentException($"User with ID '{userId}' not found.");
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
