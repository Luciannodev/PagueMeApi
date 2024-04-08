using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Repositories;

namespace PagueMe.Application.UseCase
{
    public class LoanUseCase : ILoanUseCase
    {
        private readonly ILoanRepository _repository;

        public LoanUseCase(ILoanRepository repository)
        {
            _repository = repository;
        }

        public Loan CreateLoan(Loan loan)
        {

            



            return _repository.CreateLoan(loan);


        }

        public Loan LoanPayment(Loan request)
        {
            throw new NotImplementedException();
        }
    }
}
