using AutoMapper;
using InventoryTracker.Dtos;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using Microsoft.AspNetCore.Mvc;

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
            var (computers, metadata) = await _computerService.GetAllAsync(offset, limit);

            var response = CreatePagedResponse(computers, metadata);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var computerDto = await _computerService.GetByIdAsync(id);            
            return Ok(computerDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SaveComputerDto computerDto)
        {
            var responseDto = await _computerService.AddAsync(computerDto);
            return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveComputerDto computerDto)
        {
            await _computerService.UpdateAsync(id, computerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _computerService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] ChangeStatusDto statusDto)
        {
            await _computerService.ChangeStatusAsync(id, statusDto.StatusId);
            return NoContent();
        }

        [HttpPut("{computerId}/user")]
        public async Task<IActionResult> AssignUser(int computerId, [FromBody] ChangeUserDto changeUserDto)
        {
            await _computerService.AssignUserAsync(computerId, changeUserDto.UserId);
            return NoContent();
        }

        [HttpDelete("{computerId}/user")]
        public async Task<IActionResult> UnassignUser(int computerId)
        {
            await _computerService.UnassignUserAsync(computerId);
            return NoContent();          
        }

        private PagedResponse<T> CreatePagedResponse<T>(IEnumerable<T> data, PaginationMetadata metadata)
        {
            return new PagedResponse<T>
            {
                Data = data,
                Pagination = metadata
            };
        }
    }
}
