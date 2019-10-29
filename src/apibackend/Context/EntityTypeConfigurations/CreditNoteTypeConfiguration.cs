using apibackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apibackend.Context.EntityTypeConfigurations
{
    public class CreditNoteTypeConfiguration : IEntityTypeConfiguration<CreditNote>
    {
        public void Configure(EntityTypeBuilder<CreditNote> builder)
        {
            builder.Property(c => c.CreditNoteNumber)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasMany(c => c.Insurers)
                .WithOne();

            builder.HasOne(c => c.Insured)
                .WithOne()
                .HasForeignKey<CreditNote>(c => c.InsuredId)
                .IsRequired();

            builder.HasMany(c => c.Policies)
                .WithOne();

        }
    }
}
