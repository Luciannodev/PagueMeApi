using PagueMe.Domain.Entities;
using PagueMe.Domain.Repositories;
using PagueMe.Infra.DataProvider.Context;
using System.Linq;

namespace PagueMe.Infra.DataProvider.Repositories
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
            _context.Update(creditor);
            _context.SaveChanges();
            return creditor;
        }
    }
}
