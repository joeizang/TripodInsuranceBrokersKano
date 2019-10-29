using apibackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apibackend.Context.EntityTypeConfigurations
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
