using apibackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apibackend.Context.EntityTypeConfigurations
{
    public class DebitNoteTypeConfiguration : IEntityTypeConfiguration<DebitNote>
    {
        public void Configure(EntityTypeBuilder<DebitNote> builder)
        {
            builder.HasMany(d => d.Insurers)
                .WithOne();

            builder.HasOne(d => d.Client)
                .WithOne()
                .HasForeignKey<DebitNote>(d => d.ClientId)
                .IsRequired();

            builder.HasOne(d => d.Policy)
                .WithOne()
                .HasForeignKey<DebitNote>(d => d.PolicyId)
                .IsRequired();

            builder.Property(d => d.DebitNoteNumber)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
