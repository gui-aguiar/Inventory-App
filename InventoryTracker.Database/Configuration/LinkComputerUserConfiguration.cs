using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryTracker.Database.Configuration
{
    public class LinkComputerUserConfiguration : IEntityTypeConfiguration<LinkComputerUser>
    {
        public void Configure(EntityTypeBuilder<LinkComputerUser> builder)
        {
            builder.ToTable("lnk_computer_user");

            builder.Property(l => l.Id)
                .HasColumnName("id");

            builder.Property(l => l.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(l => l.ComputerId)
                .HasColumnName("computer_id");

            builder.Property(l => l.AssignStartDate)
                .HasColumnName("assign_start_dt")
                .IsRequired();

            builder.Property(l => l.AssignEndDate)
                .HasColumnName("assign_end_dt");

            builder.HasOne(l => l.Computer)
                .WithMany(c => c.Users)
                .HasForeignKey(l => l.ComputerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.User)
                .WithMany(u => u.ComputerUsers)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
