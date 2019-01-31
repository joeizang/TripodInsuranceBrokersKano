using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.EntityTypeConfigurations
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
                .WithOne();

            builder.HasMany(c => c.Policies)
                .WithOne();

        }
    }
}
