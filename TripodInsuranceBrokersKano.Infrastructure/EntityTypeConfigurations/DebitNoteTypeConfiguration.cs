﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.EntityTypeConfigurations
{
    public class DebitNoteTypeConfiguration : IEntityTypeConfiguration<DebitNote>
    {
        public void Configure(EntityTypeBuilder<DebitNote> builder)
        {
            builder.HasMany(d => d.Insurers)
                .WithOne();

            builder.HasOne(d => d.Policy)
                .WithOne();

            builder.HasOne(d => d.Client)
                .WithOne();

            builder.Property(d => d.DebitNoteNumber)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
