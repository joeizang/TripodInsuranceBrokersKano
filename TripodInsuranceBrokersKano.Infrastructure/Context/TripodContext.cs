using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.EntityTypeConfigurations;

namespace TripodInsuranceBrokersKano.Infrastructure.Context
{
    public class TripodContext : DbContext
    {
        public TripodContext(DbContextOptions<TripodContext> options) : base(options)
        {
            
        }

        public TripodContext()
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .OwnsMany(c => c.ClientAddresses);

            modelBuilder.Entity<Insurer>()
                .OwnsOne(i => i.Address);

            modelBuilder.Entity<Insurer>()
                .OwnsOne(i => i.PhoneNumbers);

            modelBuilder.ApplyConfiguration(new PolicyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InsurerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PolicyTypeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DebitNoteTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CreditNoteTypeConfiguration());
        }
    }
}
