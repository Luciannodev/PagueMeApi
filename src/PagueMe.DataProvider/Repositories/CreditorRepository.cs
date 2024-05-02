using PagueMe.DataProvider.Context;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Interface.Repositories;

namespace PagueMe.DataProvider.Repositories
{
    public class CreditorRepository(ApplicationDbContext context) : ICreditorRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Creditor CreateCreditor(Creditor creditor)
        {
            _context.Add(creditor);
            _context.SaveChanges();
            return creditor;
        }

        public Creditor GetCreditorByIdentityNumber(string identityNumber)
        {
            Creditor? creditor = _context.Creditor.FirstOrDefault(x => x.IdentityNumber == identityNumber);
            return creditor;
        }

        public Creditor UpdateCreditor(Creditor creditor)
        {
            try
            {
                _context.Update(creditor);
                _context.SaveChanges();
                return creditor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
