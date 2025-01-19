using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryTracker.Database.Configuration
{
    public class ComputerManufacturerConfiguration : IEntityTypeConfiguration<ComputerManufacturer>
    {
        public void Configure(EntityTypeBuilder<ComputerManufacturer> builder)
        {
            builder.ToTable("computer_manufacturer");

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.SerialRegex)
                .HasColumnName("serial_regex")
                .HasMaxLength(200);
        }
    }
}
