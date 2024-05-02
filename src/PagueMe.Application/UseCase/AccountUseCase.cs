using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Interface.Repositories;
using PagueMe.Domain.Interface.Security;
using PagueMe.Infra.ExternalServices.Security;

namespace PagueMe.Application.UseCase
{
    public class AccountUseCase : IAccountUseCase
    {
        readonly private ICreditorRepository _creditorRepository ;
        readonly private IAccount _account;

        public AccountUseCase(ICreditorRepository creditorRepository,IAccount account)
        {
            _creditorRepository = creditorRepository;
            _account = account;

        }

        public bool PasswordIsValid(string password)
        {
            Creditor creditor = _creditorRepository.GetCreditorByIdentityNumber(_account.GetIdentityNumber());
            return HashHelper.CheckPassword(password, creditor.Password);
            
        }
    }
}
