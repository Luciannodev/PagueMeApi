﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PagueMe.DataProvider.Interfaces;
using PagueMe.Domain.Entities;
using PagueMe.Infra.Config;

namespace PagueMe.DataProvider.Context
{
    public class ApplicationDbContext(DbContextOptions options, IOptions<ClientSettings> settings,ILogger logger)
        : DbContext(options) , IApplicationDbContext
    {
        private readonly ILogger _logger = logger;

        public ClientSettings _settings = settings.Value;
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

            Console.WriteLine(connectionString);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)) ;
        }

        public string ConnectionStringBuilder()
        {

            var server = _settings.Database.Server;
            var database = _settings.Database.Name;
            var user = _settings.Database.User;
            var password = _settings.Database.Password;
            var port = _settings.Database.Port;
            _logger.LogInformation($"Server: {server}");
            return $"server={server};database={database};user={user};password={password};port={port}";
        }


    }
}
