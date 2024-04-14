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

        private readonly ILoanUseCase _ILoanUseCase;
        private readonly DtoToEntityHelper _DtoToEntityHelper;

        public LoanController(ILoanUseCase loanUseCase, IMapper mapper)
        {
            _ILoanUseCase = loanUseCase;
            _DtoToEntityHelper = new DtoToEntityHelper(mapper);
        }

        [HttpPost("register-loan")]
        public ActionResult<LoanResponseDTO> RegisterNewLoan(LoanRequestDTO loanRequest)
        {

            Loan loanEntity = _DtoToEntityHelper.BuildRequest(loanRequest);
            Loan registredLoan = _ILoanUseCase.CreateLoan(loanEntity);
            LoanResponseDTO loanResponse = _DtoToEntityHelper.EntityToDto(registredLoan);
            return new ActionResult<LoanResponseDTO>(loanResponse);
        }




    }
}
