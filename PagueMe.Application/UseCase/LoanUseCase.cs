using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Repositories;

namespace PagueMe.Application.UseCase
{
    public class LoanUseCase : ILoanUseCase
    {
        private readonly ILoanRepository repository;

        public LoanUseCase(ILoanRepository repository)
        {
            this.repository = repository;
        }

        public Loan CreateLoan(Loan request)
        {
            repository.CreateLoan(request);
            return repository.CreateLoan(request);
        }

        public Loan LoanPayment(Loan request)
        {
            throw new NotImplementedException();
        }
    }
}
