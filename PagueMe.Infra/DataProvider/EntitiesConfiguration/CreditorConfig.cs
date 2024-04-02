using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueMe.Domain.Entities;

namespace PagueMe.Infra.DataProvider.EntitiesConfiguration
{
    public class CreditorConfig : IEntityTypeConfiguration<Creditor>
    {
        public void Configure(EntityTypeBuilder<Creditor> builder)
        {
            builder.HasKey(x => x.CreditorId).HasName("creditor_id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Balance).HasColumnName("balance");
            builder.Property(x => x.IdentityNumber).HasColumnName("identity_number");
            builder.Property(x => x.Password).HasColumnName("password");
            builder.Property(x => x.Email).HasColumnName("email");
            
        }
    }
}
