using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryTracker.Database.Configuration
{
    public class ComputerConfiguration : IEntityTypeConfiguration<Computer>
    {
        public void Configure(EntityTypeBuilder<Computer> builder)
        {
            builder.ToTable("computer");

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.ComputerManufacturerId)
                .HasColumnName("computer_manufacturer_id");

            builder.Property(c => c.SerialNumber)
                .HasColumnName("serial_number")
                .IsRequired();

            builder.Property(c => c.Specifications)
                .HasColumnName("specifications");

            builder.Property(c => c.ImageUrl)
                .HasColumnName("image_url");

            builder.Property(c => c.PurchaseDate)
                .HasColumnName("purchase_dt");

            builder.Property(c => c.WarrantyExpirationDate)
                .HasColumnName("warranty_expiration_dt");

            builder.Property(c => c.CreateDate)
                .HasColumnName("create_dt")
                .IsRequired();

            builder.HasOne(c => c.Manufacturer)
               .WithMany(m => m.Computers)
               .HasForeignKey(c => c.ComputerManufacturerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Users)
                .WithOne(l => l.Computer)
                .HasForeignKey(l => l.ComputerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ComputerStatuses)
                .WithOne(l => l.Computer)
                .HasForeignKey(l => l.ComputerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
