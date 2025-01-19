using InventoryTracker.Contracts;
using InventoryTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IService<Computer> _computerService;

        public ComputerController(IService<Computer> computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var computers = await _computerService.GetAllAsync();
            return Ok(computers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var computer = await _computerService.GetByIdAsync(id);
            if (computer == null)
                return NotFound();

            return Ok(computer);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Computer computer)
        {
            await _computerService.AddAsync(computer);
            return CreatedAtAction(nameof(GetById), new { id = computer.Id }, computer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Computer computer)
        {
            if (id != computer.Id)
                return BadRequest("ID mismatch");

            await _computerService.UpdateAsync(computer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _computerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
