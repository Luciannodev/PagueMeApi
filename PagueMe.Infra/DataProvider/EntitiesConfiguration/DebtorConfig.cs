using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueMe.Domain.Entities;

namespace PagueMe.Infra.DataProvider.EntitiesConfiguration
{
    public class DebtorConfig : IEntityTypeConfiguration<Debtor>
    {
        public void Configure(EntityTypeBuilder<Debtor> builder)
        {
            builder.HasKey(x => x.DebtorId).HasName("id_debtor");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.IdentityNumber).HasColumnName("identity_number");

        }
    }
}
