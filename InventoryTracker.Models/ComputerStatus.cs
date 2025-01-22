namespace InventoryTracker.Models
{
    /// <summary>
    /// Represents a computer status
    /// </summary>
    public class ComputerStatus
    {
        public int Id { get; set; }
        public string LocalizedName { get; set; } = string.Empty;
        public ICollection<LinkComputerComputerStatus> ComputerStatuses { get; set; } = new List<LinkComputerComputerStatus>();
    }
}
