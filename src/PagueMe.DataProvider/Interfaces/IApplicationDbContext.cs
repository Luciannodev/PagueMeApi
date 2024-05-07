using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PagueMe.Domain.Entities;

namespace PagueMe.DataProvider.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Creditor> Creditor { get; set; }
        public DbSet<Debtor> Debtor { get; set; }
        public DbSet<Installment> Installment { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        int SaveChanges();
        EntityEntry Update(object entity);
    }
}
