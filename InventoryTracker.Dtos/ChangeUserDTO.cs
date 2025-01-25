using System.ComponentModel.DataAnnotations;

namespace InventoryTracker.Dtos
{
    public class ChangeUserDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be greater than zero.")]
        public int UserId { get; set; }
    }
}
