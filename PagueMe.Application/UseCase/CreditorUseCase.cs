using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Repositories;

namespace PagueMe.Application.UseCase
{
    public class CreditorUseCase(ICreditorRepository repository) : ICreditorUseCase
    {
        private readonly ICreditorRepository _repository = repository;

        public Creditor CreateCreditor(Creditor request)
        {
           return _repository.CreateCreditor(request);   
        }

        public Creditor UpdateCreditor(Creditor request)
        {
            throw new NotImplementedException();
        }
    }
}
