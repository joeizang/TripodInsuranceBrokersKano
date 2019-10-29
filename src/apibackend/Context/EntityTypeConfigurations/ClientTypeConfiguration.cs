using apibackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apibackend.Context.EntityTypeConfigurations
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
