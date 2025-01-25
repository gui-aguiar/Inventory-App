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
            var computerDto = await _computerService.GetDtoByIdAsync(id);
            return Ok(computerDto);        
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SaveComputerDto computerDto)
        {
            var computer = new Computer
            {
                ComputerManufacturerId = computerDto.ManufacturerId,
                SerialNumber = computerDto.SerialNumber,
                Specifications = computerDto.Specifications,
                ImageUrl = computerDto.ImageUrl,
                PurchaseDate = computerDto.PurchaseDate,
                WarrantyExpirationDate = computerDto.WarrantyExpirationDate
            };

            await _computerService.AddAsync(computer);
            var responseDto = new ComputerDto
            {
                Id = computer.Id,
                ManufacturerId = computer.ComputerManufacturerId,
                SerialNumber = computer.SerialNumber,
                Specifications = computer.Specifications,
                ImageUrl = computer.ImageUrl,
                PurchaseDate = computer.PurchaseDate,
                WarrantyExpirationDate = computer.WarrantyExpirationDate,
                StatusId = computer.ComputerStatuses.LastOrDefault()?.ComputerStatusId ?? 0,
                UserId = computer.Users.LastOrDefault(u => u.AssignEndDate != null)?.UserId
            };

            return CreatedAtAction(nameof(GetById), new { id = computer.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveComputerDto computerDto)
        {
            var existingComputer = await _computerService.GetByIdAsync(id);

            existingComputer.ComputerManufacturerId = computerDto.ManufacturerId;
            existingComputer.SerialNumber = computerDto.SerialNumber;
            existingComputer.Specifications = computerDto.Specifications;
            existingComputer.ImageUrl = computerDto.ImageUrl;
            existingComputer.PurchaseDate = computerDto.PurchaseDate;
            existingComputer.WarrantyExpirationDate = computerDto.WarrantyExpirationDate;

            await _computerService.UpdateAsync(existingComputer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _computerService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] ChangeStatusDto statusDto)
        {
            await _computerService.ChangeStatusAsync(id, statusDto.StatusId);
            return NoContent();
        }

        [HttpPut("{computerId}/user")]
        public async Task<IActionResult> AssignUserToComputer(int computerId, [FromBody] ChangeUserDto changeUserDto)
        {
            if (changeUserDto == null || changeUserDto.UserId <= 0)
            {
                return BadRequest("Invalid request payload.");
            }

            try
            {
                await _computerService.AssignUserAsync(computerId, changeUserDto.UserId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }

        [HttpDelete("{computerId}/user")]
        public async Task<IActionResult> UnassignUserToComputer(int computerId)
        {
            try
            {
                await _computerService.UnassignUserAsync(computerId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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
}
