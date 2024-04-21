using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PagueMe.DataProvider.Config;
using PagueMe.Domain.Entities;

namespace PagueMe.DataProvider.Context
{
    public class ApplicationDbContext(DbContextOptions options, IOptions<DataBaseSettings> settings)
        : DbContext(options)
    {
        public DataBaseSettings _settings = settings.Value;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConnectionStringBuilder();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public string ConnectionStringBuilder()
        {

            var server = _settings.Database.Server;
            var database = _settings.Database.Name;
            var user = _settings.Database.User;
            var password = _settings.Database.Password ;
            var port = _settings.Database.Port;
            return $"server={server};database={database};user={user};password={password};port={port}";
        }
    }
}
