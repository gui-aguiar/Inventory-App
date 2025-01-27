using System.Text.Json.Serialization;

namespace InventoryTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        
        [JsonIgnore]
        public ICollection<LinkComputerUser> ComputerUsers { get; set; } = new List<LinkComputerUser>();
    }
}
