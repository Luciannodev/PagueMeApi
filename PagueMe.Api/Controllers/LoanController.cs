using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Dtos.Response;
using PagueMe.Api.Mapper;
using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Controllers
{

    [ApiController]
    public class LoanController : ControllerBase
    {

        private readonly ILoanUseCase _IloanUseCase;

        public LoanController(ILoanUseCase loanUseCase, IMapper mapper)
        {
            _IloanUseCase = loanUseCase;
        }

        [HttpPost("register-loan")]
        public ActionResult<LoanResponseDTO> RegisterNewLoan(LoanRequestDTO loanRequest)
        {
            Loan loanEntity = DtoToEntityHelper.BuildLoanRequest(loanRequest);
            Loan registredLoan = _IloanUseCase.CreateLoan(loanEntity);
            LoanResponseDTO loanResponse = DtoToEntityHelper.EntityToDto(registredLoan);
            return new ActionResult<LoanResponseDTO>(loanResponse);
        }

        [HttpGet("list_loan")]
        public ActionResult<List<LoanResponseDTO>> ListLoan()
        {
            List<Loan> listLoan = _IloanUseCase.ListLoan();
            List<LoanResponseDTO> listLoanResponse = listLoan.Select(loan => DtoToEntityHelper.EntityToDto(loan)).ToList();
            return new ActionResult<List<LoanResponseDTO>>(listLoanResponse);

        }
    }
}
