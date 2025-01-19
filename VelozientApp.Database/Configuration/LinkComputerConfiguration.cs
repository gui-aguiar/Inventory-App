using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryTracker.Database.Configuration
{
    public class LinkComputerComputerStatusConfiguration : IEntityTypeConfiguration<LinkComputerComputerStatus>
    {
        public void Configure(EntityTypeBuilder<LinkComputerComputerStatus> builder)
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
        }
    }
}
