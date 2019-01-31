using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.EntityTypeConfigurations
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

            builder.Property(i => i.EmailAddress)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
