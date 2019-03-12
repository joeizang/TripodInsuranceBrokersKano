using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.EntityTypeConfigurations
{
    public class PolicyTypeTypeConfiguration : IEntityTypeConfiguration<PolicyType>
    {
        public void Configure(EntityTypeBuilder<PolicyType> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(50);

        }
    }
}
