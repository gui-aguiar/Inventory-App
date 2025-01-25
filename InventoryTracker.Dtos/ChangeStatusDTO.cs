using System.ComponentModel.DataAnnotations;

namespace InventoryTracker.Dtos
{
    public class ChangeStatusDto
    {
        [Required]
        public int StatusId { get; set; }
    }
}
