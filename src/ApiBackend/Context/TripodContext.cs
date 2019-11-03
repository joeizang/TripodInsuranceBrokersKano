using apibackend.Context.EntityTypeConfigurations;
using apibackend.Entities;
using apibackend.IdentityModels;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace apibackend.Context
{
    public class TripodContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public TripodContext(DbContextOptions<TripodContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
        {
            
        }
        

        public TripodContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
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
