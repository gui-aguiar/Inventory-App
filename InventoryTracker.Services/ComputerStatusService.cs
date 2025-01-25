using InventoryTracker.Contracts;
using InventoryTracker.Models;

namespace InventoryTracker.Services
{
    public class ComputerStatusService : IComputerStatusService
    {
        private readonly IRepository<ComputerStatus> _statusRepository;

        public ComputerStatusService(IRepository<ComputerStatus> statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<Status> GetCurrentStatusAsync(Computer computer)
        {
            var latestStatus = computer.ComputerStatuses
                .OrderByDescending(s => s.AssignDate)
                .FirstOrDefault();

            return latestStatus == null
                ? throw new InvalidOperationException("Computer does not have a current status.")
                : (Status)latestStatus.ComputerStatusId;
        }

        public void ValidateStatusTransition(Status currentStatus, Status newStatus)
        {
            if (!Enum.IsDefined(typeof(Status), (int)newStatus))
            {
                throw new ArgumentException($"Status ID '{(int)newStatus}' does not exist.");
            }

            if (currentStatus == (Status)newStatus)
            {
                throw new InvalidOperationException($"The computer is already in the status '{currentStatus}'.");
            }

            if (currentStatus == Status.Retired)
            {
                throw new InvalidOperationException("Computer has been retired.");
            }

            if ((Status)newStatus == Status.New)
            {
                throw new InvalidOperationException("Cannot set status back to 'New'.");
            }

            var validTransitions = new Dictionary<Status, List<Status>>
            {
                { Status.New, new List<Status> { Status.InUse } },
                { Status.InUse, new List<Status> { Status.Available, Status.InMaintenance, Status.Retired } },
                { Status.Available, new List<Status> { Status.InUse, Status.Retired } },
                { Status.InMaintenance, new List<Status> { Status.Available, Status.Retired } },
                { Status.Retired, new List<Status>() }
            };

            if (!validTransitions.TryGetValue(currentStatus, out var allowedStatuses) || !allowedStatuses.Contains(newStatus))
            {
                throw new InvalidOperationException($"Invalid status transition from '{currentStatus}' to '{newStatus}'.");
            }
        }

        public void AssignNewStatus(Computer computer, int newStatusId)
        {
            if (!Enum.IsDefined(typeof(Status), newStatusId))
            {
                throw new ArgumentException($"Status ID '{newStatusId}' does not exist.");
            }

            computer.ComputerStatuses.Add(new LinkComputerStatus
            {
                ComputerId = computer.Id,
                ComputerStatusId = newStatusId,
                AssignDate = DateTime.UtcNow
            });
        }
    }
}