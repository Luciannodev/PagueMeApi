using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Repositories;

namespace PagueMe.Application.UseCase
{
    public class CreditorUseCase(ICreditorRepository repository) : ICreditorUseCase
    {
        private readonly ICreditorRepository _repository = repository;

        public Creditor AddValueCreditor(float totalValue, string identityNumber)
        {
            Creditor creditor = _repository.GetCreditorByIdentityNumber(identityNumber);
            creditor.Balance += totalValue;
            return _repository.UpdateCreditor(creditor);
            
        }

        public Creditor CreateCreditor(Creditor request)
        {
            return _repository.CreateCreditor(request);
        }

        public Creditor GetCreditor(string identityNumber)
        {
            throw new NotImplementedException();
        }

        public Creditor UpdateCreditor(Creditor request)
        {
           return _repository.UpdateCreditor(request);
        }
    }
}
