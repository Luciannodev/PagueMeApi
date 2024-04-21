using PagueMe.Domain.Entities;

namespace PagueMe.Domain.Interface.Repositories
{
    public interface ILoanRepository
    {
        public Loan CreateLoan(Loan loan);
        public Loan UpdateLoan(Loan loan);

        public Loan GetLoanByName(string name);
        public Loan GetLoanByStatusPayment(string name);
        public Loan GetLoanByCreditor(string name);

        public Loan GetLoanByDate(string date);
        List<Loan> GetListLoanByCreditor(string v);
    }
}
