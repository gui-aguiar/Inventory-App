using InventoryTracker.Contracts;
using InventoryTracker.Dtos;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryTracker.Services
{
    public class ComputerService: IComputerService
    {
        private readonly IRepository<Computer> _repository;
        private readonly IRepository<ComputerManufacturer> _manufacturerRepository;
        private readonly IComputerStatusService _statusService;
        private readonly IComputerUserService _userService;

        public ComputerService(
            IRepository<Computer> repository,
            IRepository<ComputerManufacturer> manufacturerRepository,
            IComputerStatusService statusService,
            IComputerUserService userService
        )
        {
            _repository = repository;
            _manufacturerRepository = manufacturerRepository;
            _statusService = statusService;
            _userService = userService;
        }

        public async Task<IEnumerable<Computer>> GetAllAsync(int offset, int limit)
        {
            if (offset < 0 || limit <= 0)
                throw new ArgumentException("Offset must be >= 0 and limit must be > 0.");

            var computers = await _repository.GetAll()
                .Include(c => c.Users)
                .Include(c => c.ComputerStatuses)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return computers;
        }
        
        public async Task AddAsync(Computer computer)
        {
            await ValidateComputerAsync(computer);            
            _statusService.AssignNewStatus(computer, (int)Status.New);
            await _repository.AddAsync(computer);
        }

        public async Task<Computer> GetByIdAsync(int id)
        {
            var computer = await _repository.GetAll()
                .Include(c => c.Users)
                .Include(c => c.ComputerStatuses)
                .FirstOrDefaultAsync(c => c.Id == id);

            return computer ?? throw new KeyNotFoundException($"Computer with ID '{id}' not found.");
        }

        public async Task UpdateAsync(Computer computer)
        {                  
            await ValidateComputerAsync(computer);            
            await _repository.UpdateAsync(computer);
        }

        public async Task DeleteAsync(int id)
        {
            var computer = await GetByIdAsync(id);
            await _repository.DeleteAsync(computer);
        }

        public async Task ChangeStatusAsync(int computerId, int newStatusId)
        {
            var computer = await _repository.GetAll()
                .Include(c => c.ComputerStatuses)
                .Include(c => c.Users)
                .FirstOrDefaultAsync(c => c.Id == computerId);

            if (computer == null)
                throw new KeyNotFoundException($"Computer with ID '{computerId}' not found.");

            var currentStatus = _statusService.GetCurrentStatusAsync(computer).Result;

            ValidateStatusOpertion(newStatusId);

            _statusService.ValidateStatusTransition(currentStatus, (Status)newStatusId);

            UnassignUserIfNeeded(computer, newStatusId);

            _statusService.AssignNewStatus(computer, newStatusId);

            await _repository.UpdateAsync(computer);
        }

        public async Task AssignUserAsync(int computerId, int userId)
        {
            var computer = await _repository.GetAll()
                .Include(c => c.ComputerStatuses)
                .Include(c => c.Users)
                .FirstOrDefaultAsync(c => c.Id == computerId);
    
            if (computer == null)
                throw new KeyNotFoundException($"Computer with ID '{computerId}' not found.");

            var user = await _userService.GetUserByIdAsync(userId);

            FinalizeCurrentUserAssignment(computer);
            _userService.AssignNewUser(computer, user);
            _statusService.AssignNewStatus(computer, (int)Status.InUse);

            await _repository.UpdateAsync(computer);
        }

        public async Task UnassignUserAsync(int computerId)
        {
            var computer = await _repository.GetAll()
                .Include(c => c.Users)
                .Include(c => c.ComputerStatuses)
                .FirstOrDefaultAsync(c => c.Id == computerId);

            if (computer == null)
                throw new KeyNotFoundException($"Computer with ID '{computerId}' not found.");

            var currentAssignment = computer.Users.FirstOrDefault(u => u.AssignEndDate == null);
            if (currentAssignment == null)
                throw new InvalidOperationException($"No user is currently assigned to Computer ID '{computerId}'.");
            
            currentAssignment.AssignEndDate = DateTime.UtcNow;
            
            _statusService.AssignNewStatus(computer, (int)Status.Available);

            await _repository.UpdateAsync(computer);
        }

        public async Task<ComputerDto> GetDtoByIdAsync(int id)
        {
            var computer = await _repository.GetAll()
                .Include(c => c.Users)
                .Include(c => c.ComputerStatuses)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (computer == null)
                throw new KeyNotFoundException($"Computer with ID '{id}' not found.");

            return new ComputerDto
            {
                Id = computer.Id,
                ManufacturerId = computer.ComputerManufacturerId,
                SerialNumber = computer.SerialNumber,
                StatusId = computer.ComputerStatuses.OrderBy(cs => cs.AssignDate).LastOrDefault()?.ComputerStatusId ?? 0,
                UserId = computer.Users.LastOrDefault(u => u.AssignEndDate == null)?.UserId,
                Specifications = computer.Specifications,
                ImageUrl = computer.ImageUrl,
                PurchaseDate = computer.PurchaseDate,
                WarrantyExpirationDate = computer.WarrantyExpirationDate
            };
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _repository.GetAll().CountAsync();
        }


        private async Task ValidateComputerAsync(Computer computer)
        {
            ValidateRequiredFields(computer);
            ValidateSerialNumberFormat(computer);

            var existingComputer = await _repository.GetByIdAsync(computer.Id);
            if (existingComputer != null && existingComputer.SerialNumber != computer.SerialNumber)            
                await EnsureUniqueSerialNumberAsync(computer.SerialNumber);
            
            await EnsureValidManufacturerAsync(computer.ComputerManufacturerId);            
            ValidateDates(computer);
        }

        private void ValidateRequiredFields(Computer computer)
        {
            if (string.IsNullOrWhiteSpace(computer.SerialNumber) ||
                string.IsNullOrWhiteSpace(computer.Specifications) ||
                computer.ComputerManufacturerId <= 0)
            {
                throw new ArgumentException("All required fields must be filled.");
            }
        }

        private void ValidateSerialNumberFormat(Computer computer)
        {
            var manufacturer = _manufacturerRepository.GetByIdAsync(computer.ComputerManufacturerId).Result;
            if (manufacturer == null || string.IsNullOrWhiteSpace(manufacturer.SerialRegex))
            {
                throw new ArgumentException("Invalid manufacturer or missing serial number format.");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(computer.SerialNumber, manufacturer.SerialRegex))
            {
                throw new ArgumentException($"Invalid serial number for manufacturer '{manufacturer.Name}'.");
            }
        }

        private async Task EnsureUniqueSerialNumberAsync(string serialNumber)
        {
            if (await _repository.GetAll().AnyAsync(c => c.SerialNumber == serialNumber))
            {
                throw new ArgumentException($"Serial number '{serialNumber}' must be unique.");
            }
        }

        private async Task EnsureValidManufacturerAsync(int manufacturerId)
        {
            if (await _manufacturerRepository.GetByIdAsync(manufacturerId) == null)
            {
                throw new ArgumentException($"Manufacturer ID '{manufacturerId}' is invalid.");
            }
        }

        private void ValidateDates(Computer computer)
        {
            if (computer.PurchaseDate > DateTime.UtcNow)
            {
                throw new ArgumentException("Purchase date cannot be in the future.");
            }

            if (computer.WarrantyExpirationDate < computer.PurchaseDate)
            {
                throw new ArgumentException("Warranty expiry date must be after the purchase date.");
            }
        }

        private void ValidateStatusOpertion(int newStatusId)
        {
            if ((Status)newStatusId == Status.InUse)
            {
                throw new InvalidOperationException("Status 'In Use' can only be set via user assignment.");
            }

            if ((Status)newStatusId == Status.Available)
            {
                throw new InvalidOperationException("Status 'Available' can only be set via user unassignment.");
            }
        }

        private void UnassignUserIfNeeded(Computer computer, int newStatusId)
        {
            if ((Status)newStatusId is Status.Available or Status.InMaintenance or Status.Retired)
            {
                FinalizeCurrentUserAssignment(computer);
            }
        }
     
        private void FinalizeCurrentUserAssignment(Computer computer)
        {
            var currentAssignment = computer.Users.FirstOrDefault(u => u.AssignEndDate == null);
            if (currentAssignment != null)
            {
                currentAssignment.AssignEndDate = DateTime.UtcNow;
            }
        }
    }
}
