using PagueMe.Domain.Entities;
using System.Globalization;

namespace PagueMe.Application.Interfaces
{
    public interface ICreditorUseCase
    {
        public Creditor AddValueCreditor(float totalValue, string identityNumber);
        public Creditor CreateCreditor(Creditor request);
        public Creditor GetCreditor(string  identityNumber);
    }
}
