using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueMe.Domain.Entities;

namespace PagueMe.DataProvider.EntitiesConfiguration
{
    public class PaymentStatusConfig : IEntityTypeConfiguration<PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            builder.ToTable("payment_status");


            builder.HasKey(x => x.IdStatus).HasName("id_status");

            builder.Property(x => x.IdStatus).HasColumnName("id_status");
            builder.Property(x => x.NameStatus).HasColumnName("id_name");


        }
    }
}
