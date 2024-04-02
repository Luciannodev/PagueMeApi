using PagueMe.Domain.Entities;

namespace PagueMe.Domain.Repositories
{
    public interface ICreditorRepository
    {
        public Creditor CreateCreditor(Creditor creditor);
        public Creditor UpdateCreditor(Creditor creditor);
        public Creditor GetLoanByIdentityNumber(string identityNumber);
    }
}
