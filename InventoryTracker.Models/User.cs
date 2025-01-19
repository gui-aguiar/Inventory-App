namespace InventoryTracker.Models
{
    /// <summary>
    /// Represents a user
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }

        // Relacionamentos
        public ICollection<LinkComputerUser> ComputerUsers { get; set; } = new List<LinkComputerUser>();
    }
}
