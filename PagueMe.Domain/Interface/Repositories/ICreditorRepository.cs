using PagueMe.Domain.Entities;

namespace PagueMe.Domain.Interface.Repositories
{
    public interface ICreditorRepository
    {
        public Creditor CreateCreditor(Creditor creditor);
        public Creditor UpdateCreditor(Creditor creditor);
        public Creditor GetCreditorByIdentityNumber(string identityNumber);

    }
}
