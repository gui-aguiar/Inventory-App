using InventoryTracker.Contracts;
using InventoryTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IRepository<ComputerManufacturer> _repository;

        public ManufacturerController(IRepository<ComputerManufacturer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetManufacturers()
        {
            var manufacturers = await _repository.GetAll().ToListAsync();
            return Ok(manufacturers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var manufacturer = await _repository.GetByIdAsync(id);
            return Ok(manufacturer);
        }
    }
}