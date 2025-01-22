using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryTracker.Database.Configuration
{
    public class LinkComputerStatusConfiguration : IEntityTypeConfiguration<LinkComputerStatus>
    {
        public void Configure(EntityTypeBuilder<LinkComputerStatus> builder)
        {
            builder.ToTable("lnk_computer_computer_status");

            builder.Property(l => l.Id)
                .HasColumnName("id");

            builder.Property(l => l.ComputerId)
                .HasColumnName("computer_id");

            builder.Property(l => l.ComputerStatusId)
                .HasColumnName("computer_status_id");

            builder.Property(l => l.AssignDate)
                .HasColumnName("assign_dt")
                .IsRequired();

            builder.HasOne(l => l.Computer)
                .WithMany(c => c.ComputerStatuses)
                .HasForeignKey(l => l.ComputerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Status)
                .WithMany(cs => cs.ComputerStatuses)
                .HasForeignKey(l => l.ComputerStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
