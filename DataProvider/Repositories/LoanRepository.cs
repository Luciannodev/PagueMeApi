using Microsoft.EntityFrameworkCore;
using PagueMe.DataProvider.Context;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Interface.Repositories;
using PagueMe.Domain.Querys;

namespace PagueMe.DataProvider.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context
;
        }

        public Loan CreateLoan(Loan loan)
        {
            try
            {
                _context.Loan.Add(loan);
                _context.SaveChanges();
                return loan;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Loan> GetListLoanByCreditor(string identifyNumber)
        {
            List<Loan> loans = _context.Loan.Where(x => x.Creditor.IdentityNumber == identifyNumber).Include(d => d.Debtor).ToList();
            return loans;
        }


        public Loan UpdateLoan(Loan dto)
        {
            var loan = GetLoanById(dto.LoanId);
            UpdateFromDto(dto, loan);
            _context.Update(loan);
            _context.SaveChanges();
            return loan;
        }

        private void UpdateFromDto(Loan LoanDto, Loan loan)
        {
            if (LoanDto.Debtor.Name != null)
            {
                loan.Debtor.Name = LoanDto.Debtor.Name;
            }

            if (LoanDto.DueDate != null)
            {
                loan.DueDate = LoanDto.DueDate;
            }

            if (LoanDto.LoanValue != 0)
            {
                loan.LoanValue = LoanDto.LoanValue;
            }

            if (LoanDto.Interest != 0)
            {
                loan.Interest = LoanDto.Interest;
            }

            if (LoanDto.TotalValue != 0)
            {
                loan.TotalValue = LoanDto.TotalValue;
            }
        }

        public Loan GetLoanById(int id)
        {
            try
            {
                Loan? loan = _context.Loan
                    .Include(l => l.Debtor)
                    .SingleOrDefault(l => l.LoanId == id);
                return loan ?? throw new Exception("Loan not found");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<Loan> GetListLoan(ListLoanQuery listLoanQuery)
        {
            IQueryable<Loan> queryable = _context.Loan
                                             .Include(l => l.Debtor);
            queryable = BuildQuery(listLoanQuery, queryable);
            return queryable.ToList();
        }

        private static IQueryable<Loan> BuildQuery(ListLoanQuery listLoanQuery, IQueryable<Loan> queryable)
        {
            if (listLoanQuery.LoanId != null)
            {
                queryable = queryable.Where(x => x.LoanId == listLoanQuery.LoanId);
            }

            if (listLoanQuery.TotalValue != null)
            {
                queryable = queryable.Where(x => x.TotalValue <= listLoanQuery.TotalValue);
            }

            if (listLoanQuery.LoanValue != null)
            {
                queryable = queryable.Where(x => x.LoanValue <= listLoanQuery.LoanValue);
            }

            if (listLoanQuery.PaymentStatus != null)
            {
                queryable = queryable.Where(x => x.PaymentStatus == listLoanQuery.PaymentStatus);
            }

            if (listLoanQuery.CreditorIdentifyNumber != null)
            {
                queryable = queryable.Where(x => x.Creditor.IdentityNumber == listLoanQuery.CreditorIdentifyNumber);
            }
            if (listLoanQuery.DueDate != null)
            {
                queryable = queryable.Where(x => x.DueDate == Convert.ToDateTime(listLoanQuery.DueDate));
            }
            if(listLoanQuery.DebtorIdentifyNumber != null)
            {
                queryable = queryable.Where(x => x.Debtor.IdentityNumber == listLoanQuery.DebtorIdentifyNumber);
            }

            return queryable;
        }
    }
}
