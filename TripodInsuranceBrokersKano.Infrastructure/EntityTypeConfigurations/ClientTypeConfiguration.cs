using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.EntityTypeConfigurations
{
    public class ClientTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.ContactPerson).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(200);

            builder.OwnsOne(c => c.ClientAddress);

            builder.OwnsOne(c => c.OtherAddress);

        }
    }
}
