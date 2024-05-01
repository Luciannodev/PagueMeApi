using PagueMe.Domain.Entities;
using PagueMe.Domain.Querys;

namespace PagueMe.Application.Interfaces
{
    public interface ILoanUseCase
    {
        public Loan CreateLoan(Loan request);

        public Loan LoanPayment(Loan request);

        public List<Loan> ListLoan(ListLoanQuery listLoanQuery);
        Loan LoanUpdate(Loan loanEntity);
    }
}
