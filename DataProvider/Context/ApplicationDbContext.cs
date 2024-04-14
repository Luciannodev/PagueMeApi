using Microsoft.EntityFrameworkCore;
using PagueMe.Domain.Entities;

namespace PagueMe.DataProvider.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Creditor> Creditor { get; set; }
        public DbSet<Debtor> Debtor { get; set; }
        public DbSet<Installment> Installment { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
