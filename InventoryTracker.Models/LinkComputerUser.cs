namespace InventoryTracker.Models
{
    /// <summary>
    /// Represents the relationship between a computer and a user
    /// </summary>
    public class LinkComputerUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ComputerId { get; set; }
        public DateTime AssignStartDate { get; set; }
        public DateTime AssignEndDate { get; set; }

        public User User { get; set; } = null!;
        public Computer Computer { get; set; } = null!;
    }
}