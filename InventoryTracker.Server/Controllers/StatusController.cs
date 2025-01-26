using InventoryTracker.Contracts;
using InventoryTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IRepository<ComputerStatus> _repository;

        public StatusController(IRepository<ComputerStatus> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            var statuses = await _repository.GetAll().ToListAsync();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusById(int id)
        {
            var status = await _repository.GetByIdAsync(id);
            return Ok(status);
        }
    }
}