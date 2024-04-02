using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueMe.Domain.Entities;

namespace PagueMe.Infra.DataProvider.EntitiesConfiguration
{
    public class PaymentStatusConfig : IEntityTypeConfiguration<PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            builder.HasKey(x => x.IdStatus).HasName("id_status");
            builder.Property(x => x.IdName).HasColumnName("id_name");
        }
    }
}
