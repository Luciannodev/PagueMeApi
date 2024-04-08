using PagueMe.Domain.Entities;
using System.Net.NetworkInformation;

namespace PagueMe.Infra.DataProvider.Context
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DataSeeder(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Seed ()
        {
            if (!_applicationDbContext.PaymentStatus.Any())
            {
                _applicationDbContext.Add(new PaymentStatus() { IdStatus = 1, NameStatus = "Pendente" });
                _applicationDbContext.Add(new PaymentStatus() { IdStatus = 2, NameStatus = "Pago" });
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
