using PagueMe.Domain.Entities;
using PagueMe.Domain.Repositories;
using PagueMe.Infra.DataProvider.Context;

namespace PagueMe.Infra.DataProvider.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Loan CreateLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return loan;
        }

        public Loan GetLoanByCreditor(string name)
        {
            throw new NotImplementedException();
        }

        public Loan GetLoanByDate(string date)
        {
            throw new NotImplementedException();
        }

        public Loan GetLoanByName(string name)
        {
            throw new NotImplementedException();
        }

        public Loan GetLoanByStatusPayment(string name)
        {
            throw new NotImplementedException();
        }

        public Loan UpdateLoan(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
