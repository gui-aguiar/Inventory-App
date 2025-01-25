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
        private readonly IMapper _mapper;

        public ComputerController(IComputerService computerService, IMapper mapper)
        {
            _computerService = computerService;
            _mapper = mapper;
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
                Data = _mapper.Map<IEnumerable<ComputerDto>>(computers),
                Pagination = paginationMetadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var computer = await _computerService.GetByIdAsync(id);
            var computerDto = _mapper.Map<ComputerDto>(computer);
            return Ok(computerDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SaveComputerDto computerDto)
        {
            var computer = _mapper.Map<Computer>(computerDto);
            await _computerService.AddAsync(computer);

            var responseDto = _mapper.Map<ComputerDto>(computer);
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
            await _computerService.AssignUserAsync(computerId, changeUserDto.UserId);
            return NoContent();
        }

        [HttpDelete("{computerId}/user")]
        public async Task<IActionResult> UnassignUserToComputer(int computerId)
        {
            await _computerService.UnassignUserAsync(computerId);
            return NoContent();          
        }
    }
}
