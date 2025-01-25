using System.ComponentModel.DataAnnotations;

namespace InventoryTracker.Dtos
{
    public class ChangeStatusDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "StatusId must be greater than zero.")]
        public int StatusId { get; set; }
    }
}
