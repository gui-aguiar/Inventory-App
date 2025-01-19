using InventoryTracker.Contracts;
using InventoryTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }
    }
}
