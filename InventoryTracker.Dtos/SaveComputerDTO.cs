using System.ComponentModel.DataAnnotations;

namespace InventoryTracker.Dtos
{
    public class SaveComputerDto
    {
        [Required]
        public int ManufacturerId { get; set; }
        [Required]
        public string SerialNumber { get; set; } = string.Empty;
        public string Specifications { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpirationDate { get; set; }
    }
}