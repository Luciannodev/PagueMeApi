using Microsoft.Extensions.Logging;
using PagueMe.Domain.Entities;

namespace PagueMe.DataProvider.Context
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger _logger;

        public DataSeeder(ApplicationDbContext applicationDbContext,ILogger logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public void Seed()
        {

            try
            {
                
                if (!_applicationDbContext.PaymentStatus.Any())
                {
                    _applicationDbContext.Add(new PaymentStatus() { IdStatus = 1, NameStatus = "Pendente" });
                    _applicationDbContext.Add(new PaymentStatus() { IdStatus = 2, NameStatus = "Pago" });
                    _applicationDbContext.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw new Exception("Erro ao popular a base de dados", ex);
            }

        }
    }
}
