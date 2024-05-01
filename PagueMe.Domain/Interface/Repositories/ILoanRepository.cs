using PagueMe.Domain.Entities;
using PagueMe.Domain.Querys;

namespace PagueMe.Domain.Interface.Repositories
{
    public interface ILoanRepository
    {
        public Loan CreateLoan(Loan loan);
        public Loan UpdateLoan(Loan loan);

        public Loan GetLoanByDate(string date);
        List<Loan> GetListLoanByCreditor(string v);

        public List<Loan> GetListLoan(ListLoanQuery listLoanQuery);
    }
}
