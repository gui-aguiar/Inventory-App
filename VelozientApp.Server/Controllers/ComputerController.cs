using InventoryTracker.Contracts;
using InventoryTracker.Dtos;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {

            var totalItems = await _computerService.GetTotalCountAsync();
            var computers = await _computerService.GetAllAsync(offset, limit);

            var paginationMetadata = new PaginationMetadata
            {
                TotalItems = totalItems,
                PageSize = limit,
                CurrentPage = (offset / limit) + 1,
                TotalPages = (int)Math.Ceiling(totalItems / (double)limit)
            };

            var response = new PagedResponse<ComputerDto>
            {
                Data = computers,
                Pagination = paginationMetadata
            };

            return Ok(response);
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

        [HttpPost("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] ChangeStatusRequest request)
        {
            try
            {
                await _computerService.ChangeStatusAsync(id, request.StatusId);
                return NoContent();
            }

            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred.", Details = ex.Message });
            }
        }

        [HttpPut("{computerId}/assign-user")]
        public async Task<IActionResult> AssignUserToComputer(int computerId, [FromBody] AssignUserRequest request)
        {
            if (request == null || request.UserId <= 0)
            {
                return BadRequest("Invalid request payload.");
            }

            try
            {
                await _computerService.AssignUserAsync(computerId, request.UserId);
                return NoContent(); // Indicating the action was successful
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // For invalid inputs
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message); // For logical inconsistencies
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }
    }
    public class ChangeStatusRequest
    {
        public int StatusId { get; set; }
    }

    public class AssignUserRequest
    {
        public int UserId { get; set; }
    }
}
