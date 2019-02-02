using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.EntityTypeConfigurations
{
    public class PolicyTypeConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.Property(p => p.InternalPolicyNumber)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(p => p.InsurerPolicyNumber)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasIndex(p => p.InsurerPolicyNumber);

            builder.HasIndex(p => p.InternalPolicyNumber);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.PolicyTermDocument)
                .HasMaxLength(4000);

            builder.HasOne(p => p.Insured)
                .WithMany(c => c.Policies)
                .HasForeignKey(p => p.InsuredId)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(2000);

            builder.HasMany(p => p.Insurers)
                .WithOne();

            builder.HasOne(p => p.PolicyType)
                .WithOne()
                .HasForeignKey<Policy>(p => p.PolicyTypeId);
        }
    }
}
