using apibackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apibackend.Context.EntityTypeConfigurations
{
    public class InsurerTypeConfiguration : IEntityTypeConfiguration<Insurer>
    {
        public void Configure(EntityTypeBuilder<Insurer> builder)
        {
            builder.Property(i => i.ContactPerson)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(i => i.InsurerName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(i => i.InsurerName).IsUnique();

            builder.Property(i => i.EmailAddress)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
