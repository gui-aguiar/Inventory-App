namespace InventoryTracker.Dtos
{
    public class ComputerDto
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string SerialNumber { get; set; }
        public int StatusId { get; set; }
        public int? UserId { get; set; }
        public string Specifications { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpirationDate { get; set; }
    }
}
