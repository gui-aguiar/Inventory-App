using InventoryTracker.Database;
using Microsoft.EntityFrameworkCore;

namespace VelozientApp.Database
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
