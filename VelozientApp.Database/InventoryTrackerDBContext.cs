using InventoryTracker.Database.Configuration;
using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryTracker.Database
{
    public class InventoryTrackerDBContext : DbContext
    {
        public InventoryTrackerDBContext(DbContextOptions<InventoryTrackerDBContext> options)
            : base(options)
        {
        }

        public DbSet<ComputerManufacturer> ComputerManufacturers { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerStatus> ComputerStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LinkComputerStatus> ComputerComputerStatuses { get; set; }
        public DbSet<LinkComputerUser> ComputerUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define o schema padrão (se necessário)
            modelBuilder.HasDefaultSchema("Inventory");  // isso aqui nao sei se precisa 

            // Aplica as configurações de cada entidade
            modelBuilder.ApplyConfiguration(new ComputerManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new ComputerConfiguration());
            modelBuilder.ApplyConfiguration(new ComputerStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LinkComputerStatusConfiguration());
            modelBuilder.ApplyConfiguration(new LinkComputerUserConfiguration());

            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Computer>().ToTable("computer");
            modelBuilder.Entity<ComputerManufacturer>().ToTable("computer_manufacturer");
            modelBuilder.Entity<ComputerStatus>().ToTable("computer_status");
            modelBuilder.Entity<LinkComputerUser>().ToTable("lnk_computer_user");
            modelBuilder.Entity<LinkComputerStatus>().ToTable("lnk_computer_computer_status");
        }
   
    }
}

