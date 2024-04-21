using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Interface.Repositories;
using PagueMe.Domain.Interface.Security;
using System.IdentityModel.Tokens.Jwt;

namespace PagueMe.Application.UseCase
{
    public class LoanUseCase : ILoanUseCase
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ICreditorUseCase _creditorUseCase;
        private readonly IAccount _account;


        public LoanUseCase(ILoanRepository loanRepository, ICreditorUseCase creditorUseCase,
            IAccount account
            )
        {

            _loanRepository = loanRepository;
            _creditorUseCase = creditorUseCase;
            _account = account;
        }

        public Loan CreateLoan(Loan loan)
        {
            Creditor creditor = _creditorUseCase.AddValueToCreditor(_account.GetIdentityNumber(), loan.TotalValue);
            loan.Creditor = creditor;
            return _loanRepository.CreateLoan(loan);


        }

        public List<Loan> ListLoan()
        {
            List<Loan> loanList = _loanRepository.GetListLoanByCreditor(_account.GetIdentityNumber());
            return loanList;
        }

        public Loan LoanPayment(Loan request)
        {
            throw new NotImplementedException();
        }


    }
}
