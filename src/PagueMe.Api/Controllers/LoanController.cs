using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Dtos.Response;
using PagueMe.Api.Mapper;
using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Querys;

namespace PagueMe.Api.Controllers
{

    [ApiController]
    public class LoanController : ControllerBase
    {

        private readonly ILoanUseCase _loanUseCase;

        public LoanController(ILoanUseCase loanUseCase, IMapper mapper)
        {
            _loanUseCase = loanUseCase;
        }

        [HttpPost("register-loan")]
        public ActionResult<LoanResponseDTO> RegisterNewLoan(LoanRegisterRequestDTO loanRequest)
        {
            Loan loanEntity = DtoToEntityHelper.BuildLoanRequest(loanRequest);
            Loan registredLoan = _loanUseCase.CreateLoan(loanEntity);
            LoanResponseDTO loanResponse = DtoToEntityHelper.LoanEntityToDto(registredLoan);
            return new ActionResult<LoanResponseDTO>(loanResponse);
        }

        [HttpGet("list_loan")]
        public ActionResult<List<LoanResponseDTO>> ListLoans(GetLoanQuery getLoanQuery)
        {
            ListLoanQuery query = DtoToEntityHelper.BuildGetLoanQuery(getLoanQuery);
            List<Loan> listLoan = _loanUseCase.ListLoan(query);
            List<LoanResponseDTO> listLoanResponse = listLoan.Select(DtoToEntityHelper.LoanEntityToDto).ToList();
            return new ActionResult<List<LoanResponseDTO>>(listLoanResponse);

        }


        [HttpPut("update_loan")]
        public ActionResult<LoanResponseDTO> UpdateLoan(LoanUpdateRequestDTO loanRequest)
        {
            Loan loanEntity = DtoToEntityHelper.LoanDtoToEntity(loanRequest);
            Loan listLoan = _loanUseCase.LoanUpdate(loanEntity);
            LoanResponseDTO loanResponse = DtoToEntityHelper.LoanEntityToDto(listLoan);
            return new ActionResult<LoanResponseDTO>(loanResponse);

        }
    }
}
