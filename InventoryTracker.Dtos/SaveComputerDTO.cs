namespace InventoryTracker.Dtos
{
    public class SaveComputerDto
    {      
        public int ManufacturerId { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string Specifications { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpirationDate { get; set; }
    }
}