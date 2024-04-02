using Microsoft.AspNetCore.Mvc;
using Pagame.Api.Dtos;
using Pagame.Api.Mapper;
using PagueMe.Application.UseCase;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Controllers
{

    [ApiController]
    public class LoanController(LoanMapper loanMapper, LoanUseCase iLoanUseCase) : ControllerBase
    {
        public LoanMapper LoanMapper = loanMapper;
        public LoanUseCase ILoanUseCase = iLoanUseCase;

        [HttpPost("register-loan")]
        public ActionResult<Loan> RegisterNewLoan(LoanRequestDTO loanRequest)
        {
            Loan loanEntity = LoanMapper.DtotoEntity(loanRequest);
            Loan registedLoan = ILoanUseCase.CreateLoan(loanEntity);
            return new ActionResult<Loan>(registedLoan);
        }
    }
}
