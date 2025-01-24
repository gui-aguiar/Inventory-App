using InventoryTracker.Contracts;
using InventoryTracker.Dtos;
using InventoryTracker.Interfaces;
using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryTracker.Services
{
    public class ComputerService : Service<Computer>, IComputerService
    {
        private readonly IRepository<ComputerManufacturer> _manufacturerRepository;
        private readonly IComputerStatusService _statusService;
        private readonly IComputerUserService _userService;

        public ComputerService(
            IRepository<Computer> repository,
            IRepository<ComputerManufacturer> manufacturerRepository,
            IComputerStatusService statusService,
            IComputerUserService userService
        ) : base(repository)
        {
            _manufacturerRepository = manufacturerRepository;
            _statusService = statusService;
            _userService = userService;
        }

        public async Task<IEnumerable<ComputerDto>> GetAllAsync(int offset, int limit)
        {
            var computers = await _repository.GetAll()
                .Include(c => c.Users)
                .Include(c => c.ComputerStatuses)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return computers.Select(c => new ComputerDto
            {
                Id = c.Id,
                ManufacturerId = c.ComputerManufacturerId,
                SerialNumber = c.SerialNumber,
                StatusId = c.ComputerStatuses.LastOrDefault()?.ComputerStatusId ?? 0,
                UserId = c.Users.LastOrDefault()?.Id,
                Specifications = c.Specifications,
                ImageUrl = c.ImageUrl,
                PurchaseDate = c.PurchaseDate,
                WarrantyExpirationDate = c.WarrantyExpirationDate
            });
        }
        public override async Task AddAsync(Computer computer)
        {
            await ValidateComputerAsync(computer);            
            _statusService.AssignNewStatus(computer, (int)Status.New);
            await base.AddAsync(computer);
        }

        public override async Task UpdateAsync(Computer computer)
        {   
            await ValidateComputerAsync(computer);            
            await _repository.UpdateAsync(computer);
        }

        public async Task ChangeStatusAsync(int computerId, int newStatusId)
        {
            var computer = await GetComputerOrThrowAsync(computerId);

            ValidateStatusChange(computer, newStatusId);
            UnassignUserIfNeeded(computer, newStatusId);

            _statusService.AssignNewStatus(computer, newStatusId);

            await _repository.UpdateAsync(computer);
        }

        public async Task AssignUserAsync(int computerId, int userId)
        {
            var computer = await GetComputerOrThrowAsync(computerId);
            var user = await _userService.GetUserOrThrowAsync(userId);

            EnsureCanAssignUser(computer);

            FinalizeCurrentUserAssignment(computer);
            _userService.AssignNewUser(computer, user);

            _statusService.AssignNewStatus(computer, (int)Status.InUse);

            await _repository.UpdateAsync(computer);
        }

        // ----------- Private Helper Methods -----------

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

        private void EnsureCanAssignUser(Computer computer)
        {
            var currentStatus = _statusService.GetCurrentStatusAsync(computer).Result;

            if (currentStatus != Status.Available && currentStatus != Status.New)
            {
                throw new InvalidOperationException($"Cannot assign a user to a computer in the status '{currentStatus}'.");
            }
        }

        private async Task<Computer> GetComputerOrThrowAsync(int computerId)
        {
            var computer = await _repository.GetByIdAsync(computerId);
            return computer ?? throw new ArgumentException($"Computer with ID '{computerId}' not found.");
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

        private void ValidateStatusChange(Computer computer, int newStatusId)
        {
            var currentStatus = _statusService.GetCurrentStatusAsync(computer).Result;

            if (currentStatus == (Status)newStatusId)
            {
                throw new InvalidOperationException($"The computer is already in the status '{currentStatus}'.");
            }

            if ((Status)newStatusId == Status.New)
            {
                throw new InvalidOperationException("Cannot set status back to 'New'.");
            }

            if ((Status)newStatusId == Status.InUse)
            {
                throw new InvalidOperationException("Status 'In Use' can only be set via user assignment.");
            }

            _statusService.ValidateStatusTransition(currentStatus, (Status)newStatusId);
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
