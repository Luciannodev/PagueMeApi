using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagueMe.Domain.Entities;

namespace PagueMe.Infra.DataProvider.EntitiesConfiguration
{
    public class LoanConfig : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(x => x.LoanId).HasName("loan_id");
            builder.Property(x => x.TotalValue).HasColumnName("total_value");
            builder.Property(x => x.PaymentStatus).HasColumnName("payment_status");
            builder.Property(x => x.CreditorId).HasColumnName("creditor_id");
            builder.Property(x => x.DebtorId).HasColumnName("debtor_id");
            builder.Property(x => x.DueDate).HasColumnName("due_data");
            builder.Property(x => x.RegistrationDate).HasColumnName("registration_date");

            builder.HasOne(x => x.Debtor)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.DebtorId);

            builder.HasOne(x => x.Creditor)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.CreditorId);
        }
    }
}
