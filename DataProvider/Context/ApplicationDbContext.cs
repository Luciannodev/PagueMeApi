using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PagueMe.DataProvider.Config;
using PagueMe.Domain.Entities;

namespace PagueMe.DataProvider.Context
{
    public class ApplicationDbContext(DbContextOptions options, IOptions<DataBaseSettings> settings,IConfiguration configuration)
        : DbContext(options)
    {
        public IConfiguration _configuration = configuration;
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


            var server = _configuration["DataBaseSettings:Database:Server"];
            var database = _configuration["DataBaseSettings:Database:Name"];
            var user = _configuration["DataBaseSettings:Database:User"];
            var password = _configuration["DataBaseSettings:Database:password"];
            var port = _configuration["DataBaseSettings:Database:port"];

            return $"server={server};database={database};user={user};password={password};port={port}";
        }
    }
}
