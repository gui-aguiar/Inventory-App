using InventoryTracker.Contracts;
using InventoryTracker.Models;

namespace InventoryTracker.Services
{
    public class ComputerService : Service<Computer>
    {
        private readonly IRepository<ComputerManufacturer> _manufacturerRepository;
        private readonly IRepository<ComputerStatus> _statusRepository;
        public ComputerService(
            IRepository<Computer> repository,
            IRepository<ComputerManufacturer> manufacturerRepository,
            IRepository<ComputerStatus> statusRepository
        ) : base(repository)
        {
            _manufacturerRepository = manufacturerRepository;
            _statusRepository = statusRepository;
        }

        public override async Task AddAsync(Computer computer)
        {
            await ValidateComputerAsync(computer);
            await base.AddAsync(computer);
        }

        public override async Task UpdateAsync(Computer computer)
        {
            await ValidateComputerAsync(computer);
            await base.UpdateAsync(computer);
        }

        private async Task ValidateComputerAsync(Computer computer)
        {
            if (string.IsNullOrWhiteSpace(computer.SerialNumber) ||
                string.IsNullOrWhiteSpace(computer.Specifications) ||
                computer.ComputerManufacturerId == null)
            {
                throw new ArgumentException("All required fields must be filled.");
            }

            if (!await IsSerialNumberUniqueAsync(computer.SerialNumber))
            {
                throw new ArgumentException("Serial number must be unique.");
            }

            if (!await IsManufacturerValidAsync(computer.ComputerManufacturerId))
            {
                throw new ArgumentException("Invalid manufacturer.");
            }

            var manufacturer = await _manufacturerRepository.GetByIdAsync(computer.ComputerManufacturerId);
            if (!ValidateSerialNumber(computer, manufacturer))
            {
                throw new ArgumentException($"Invalid serial number for manufacturer {manufacturer.Name}.");
            }

            if (computer.PurchaseDate > DateTime.UtcNow)
            {
                throw new ArgumentException("Purchase date cannot be in the future.");
            }

            if (computer.WarrantyExpirationDate < computer.PurchaseDate)
            {
                throw new ArgumentException("Warranty expiry date must be after the purchase date.");
            }

            if (!await IsStatusValidAsync(computer))
            {
                throw new ArgumentException("Invalid status.");
            }
        }

        public async Task<bool> IsSerialNumberUniqueAsync(string serialNumber)
        {
            var existingComputer = await _repository.GetAllAsync()
                .FirstOrDefaultAsync(c => c.SerialNumber == serialNumber);
            return existingComputer == null;
        }

        private async Task<bool> IsManufacturerValidAsync(int manufacturerId)
        {
            var manufacturer = await _manufacturerRepository.GetByIdAsync(manufacturerId);
            return manufacturer != null;
        }

        private bool ValidateSerialNumber(Computer computer, ComputerManufacturer manufacturer)
        {
            var regex = manufacturer.SerialRegex;
            if (string.IsNullOrWhiteSpace(regex))
            {
                throw new ArgumentException($"No serial number pattern defined for manufacturer {manufacturer.Name}.");
            }

            return System.Text.RegularExpressions.Regex.IsMatch(computer.SerialNumber, regex);
        }
        public async Task<bool> IsStatusValidAsync(int statusId)
        {
            if (!Enum.IsDefined(typeof(Status), statusId))
            {
                return false;
            }

            var status = await _statusRepository.GetByIdAsync(statusId);  // add aqui as validacoes de status
            return status != null;
        }

        private void ValidateStatusTransition(Status currentStatus, Status newStatus)
        {
            if (currentStatus == newStatus)           
                return;

            var validTransitions = new Dictionary<Status, List<Status>>
            {
                { Status.New, new List<Status> { Status.InUse } },
                { Status.InUse, new List<Status> { Status.Available, Status.InMaintenance, Status.Retired } },
                { Status.Available, new List<Status> { Status.InUse, Status.Retired } },
                { Status.InMaintenance, new List<Status> { Status.Available, Status.Retired } },
                { Status.Retired, new List<Status>() }
            };

            if (!validTransitions[currentStatus].Contains(newStatus))
            {
                throw new InvalidOperationException($"Invalid status transition from {currentStatus} to {newStatus}");
            }
        }
    }
}
