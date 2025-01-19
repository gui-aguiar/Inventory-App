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
            computer.ComputerStatuses.Add(new LinkComputerComputerStatus
            {
                ComputerId = computer.Id,
                ComputerStatusId = newStatusId,
                AssignDate = DateTime.UtcNow
            });
        }

        /*private bool ValidateStatusTransition(Status currentStatus, Status newStatus)
       {
           var validTransitions = new Dictionary<Status, List<Status>>
           {
               { Status.New, new List<Status> { Status.InUse } },
               { Status.InUse, new List<Status> { Status.Available, Status.InMaintenance, Status.Retired } },
               { Status.Available, new List<Status> { Status.InUse, Status.Retired } },
               { Status.InMaintenance, new List<Status> { Status.Available, Status.Retired } },
               { Status.Retired, new List<Status>() }
           };

           return validTransitions.TryGetValue(currentStatus, out var allowedStatuses)
               && allowedStatuses.Contains(newStatus);
       }

        private bool ValidateStatusTransition(Status currentStatus, Status newStatus)
        {
            var validTransitions = new Dictionary<Status, List<Status>>
            {
                { Status.New, new List<Status> { Status.InUse } },
                { Status.InUse, new List<Status> { Status.Available, Status.InMaintenance, Status.Retired } },
                { Status.Available, new List<Status> { Status.InUse, Status.Retired } },
                { Status.InMaintenance, new List<Status> { Status.Available, Status.Retired } },
                { Status.Retired, new List<Status>() }
            };

            return validTransitions[currentStatus].Contains(newStatus);
        }*/
    }
}