using InventoryTracker.Contracts;
using InventoryTracker.Models;
using Microsoft.AspNetCore.Mvc;

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
        var manufacturers = await _repository.GetAllAsync();
        return Ok(manufacturers);
    }
}
