using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueMe.Domain.Entities;

namespace PagueMe.Infra.DataProvider.EntitiesConfiguration
{
    public class InstallmentConfig : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> builder)
        {
            builder.HasKey(x => x.InstallmentsOrder).HasName("installments_order");
            builder.Property(x => x.LoanId).HasColumnName("loan_id");
            builder.Property(x => x.Value).HasColumnName("value");
            builder.Property(x => x.StatusPayment).HasColumnName("status_payment");
            builder.Property(x => x.DueDate).HasColumnName("due_date");

            builder.HasOne(x => x.Loan)
                .WithMany(x => x.Installments)
                .HasForeignKey(x => x.LoanId);
        }
    }
}
