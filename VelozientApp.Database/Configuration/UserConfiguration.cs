using InventoryTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryTracker.Database.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.FirstName)
                .HasColumnName("first_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.EmailAddress)
                .HasColumnName("email_address")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.CreateDate)
                .HasColumnName("create_dt")
                .IsRequired();
        }
    }
}
