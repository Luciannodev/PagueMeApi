using Microsoft.EntityFrameworkCore;
using PagueMe.DataProvider.Context;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Interface.Repositories;

namespace PagueMe.DataProvider.Repositories
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
            try
            {
                _context.Loan.Add(loan);
                _context.SaveChanges();
                return loan;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }

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
