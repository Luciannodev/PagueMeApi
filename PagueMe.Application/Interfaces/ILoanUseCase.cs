using PagueMe.Domain.Entities;

namespace PagueMe.Application.Interfaces
{
    public interface ILoanUseCase
    {
        public Loan CreateLoan(Loan request);

        public Loan LoanPayment(Loan request);

    }
}
