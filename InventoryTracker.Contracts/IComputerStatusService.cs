using InventoryTracker.Models;
namespace InventoryTracker.Contracts

{
    public interface IComputerStatusService
    {
        Task<Status> GetCurrentStatusAsync(Computer computer);
        void ValidateStatusTransition(Status currentStatus, Status newStatus);
        void AssignNewStatus(Computer computer, int newStatusId);
    }
}
