using apibackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apibackend.Context.EntityTypeConfigurations
{
    public class RecieptTypeConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.Property(r => r.ChequeOrDraftNumber)
                .HasMaxLength(25);

            builder.HasOne(r => r.Policy)
                .WithOne()
                .HasForeignKey<Receipt>(r => r.PolicyId)
                .IsRequired();

            builder.HasOne(r => r.Payer)
                .WithOne()
                .HasForeignKey<Receipt>(r => r.ClientId)
                .IsRequired();
        }
    }
}
