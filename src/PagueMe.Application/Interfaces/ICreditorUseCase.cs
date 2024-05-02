using PagueMe.Domain.Entities;
using System.Globalization;

namespace PagueMe.Application.Interfaces
{
    public interface ICreditorUseCase
    {
        public Creditor AddValueToCreditor(string identityNumber, float totalValue);
        public Creditor CreateCreditor(Creditor request);
        public Creditor GetCreditor(string  identityNumber);
    }
}
