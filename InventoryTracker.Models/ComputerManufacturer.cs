﻿namespace InventoryTracker.Models
{
    public class ComputerManufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SerialRegex { get; set; } = string.Empty;

        public ICollection<Computer> Computers { get; set; } = new List<Computer>();
    }
}
