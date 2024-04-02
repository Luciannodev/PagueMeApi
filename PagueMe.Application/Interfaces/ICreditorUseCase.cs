using PagueMe.Domain.Entities;

namespace PagueMe.Application.Interfaces
{
    public interface ICreditorUseCase
    {
        public Creditor CreateCreditor(Creditor request);

        public Creditor UpdateCreditor(Creditor request);
    }
}
