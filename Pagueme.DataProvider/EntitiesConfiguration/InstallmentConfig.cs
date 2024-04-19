using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueMe.Domain.Entities;

namespace PagueMe.DataProvider.EntitiesConfiguration
{
    public class InstallmentConfig : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> builder)
        {
            builder.HasKey(x => x.InstallmentsOrder);
            builder.Property(x => x.InstallmentsOrder).HasColumnName("installment_order");
            builder.Property(x => x.LoanId).HasColumnName("loan_id");
            builder.Property(x => x.Value).HasColumnName("value");
            builder.Property(x => x.PaymentStatus).HasColumnName("status_payment");
            builder.Property(x => x.DueDate).HasColumnName("due_date");
            builder.Property(x => x.Interest).HasColumnName("interest");

            builder.HasOne(x => x.Loan)
                .WithMany(x => x.Installment)
                .HasForeignKey(x => x.LoanId);
        }
    }
}
