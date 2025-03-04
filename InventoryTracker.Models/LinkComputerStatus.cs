﻿namespace InventoryTracker.Models
{
    public class LinkComputerStatus
    {
        public int Id { get; set; }
        public int ComputerId { get; set; }
        public int ComputerStatusId { get; set; }
        public DateTime AssignDate { get; set; }

        public Computer Computer { get; set; } = null!;
        public ComputerStatus Status { get; set; } = null!;
    }
}