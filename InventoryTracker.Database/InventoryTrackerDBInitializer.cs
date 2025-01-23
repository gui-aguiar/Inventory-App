using Microsoft.EntityFrameworkCore;

namespace InventoryTracker.Database
{
    public static class InventoryTrackerDBInitializer
    {
        public static void Initialize(InventoryTrackerDBContext context)
        {
            // Aplica migrations pendentes
            context.Database.Migrate();
        }
    }
}
