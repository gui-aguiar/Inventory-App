using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryTracker.Database.Configuration
{
    public class ComputerStatusConfiguration : IEntityTypeConfiguration<ComputerStatus>
    {
        public void Configure(EntityTypeBuilder<ComputerStatus> builder)
        {
            builder.ToTable("computer_status");

            builder.Property(cs => cs.Id)
                .HasColumnName("id");

            builder.Property(cs => cs.LocalizedName)
                .HasColumnName("localized_name")
                .IsRequired();

            builder.HasMany(cs => cs.ComputerStatuses)
                .WithOne(l => l.Status)
                .HasForeignKey(l => l.ComputerStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
