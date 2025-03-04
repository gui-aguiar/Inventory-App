﻿namespace InventoryTracker.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public int ComputerManufacturerId { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string Specifications { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpirationDate { get; set; }
        public DateTime CreateDate { get; set; }

        public ComputerManufacturer Manufacturer { get; set; } = null!;
        public ICollection<LinkComputerStatus> ComputerStatuses { get; set; } = new List<LinkComputerStatus>();
        public ICollection<LinkComputerUser> Users { get; set; } = new List<LinkComputerUser>();
    }
}