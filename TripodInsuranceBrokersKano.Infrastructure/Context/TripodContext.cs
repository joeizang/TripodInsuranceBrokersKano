using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.EntityTypeConfigurations;
using TripodInsuranceBrokersKano.Infrastructure.IdentityModels;

namespace TripodInsuranceBrokersKano.Infrastructure.Context
{
    public class TripodContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
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
            modelBuilder.ApplyConfiguration(new RecieptTypeConfiguration());
        }

        public DbSet<Policy> Policies { get; set; }

        public DbSet<DebitNote> DebitNotes { get; set; }

        public DbSet<CreditNote> CreditNotes { get; set; }

        public DbSet<Insurer> Insurers { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<PolicyType> PolicyTypes { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
    }
}
