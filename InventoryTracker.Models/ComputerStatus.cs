using System.Text.Json.Serialization;

namespace InventoryTracker.Models
{
    public class ComputerStatus
    {
        public int Id { get; set; }
        public string LocalizedName { get; set; } = string.Empty;
        
        [JsonIgnore]
        public ICollection<LinkComputerStatus> ComputerStatuses { get; set; } = new List<LinkComputerStatus>();
    }
}
