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
        private readonly DtoToEntityHelper _dtoHelper;

        public LoanController(ILoanUseCase loanUseCase, IMapper mapper)
        {
            _IloanUseCase = loanUseCase;
            _dtoHelper = new DtoToEntityHelper(mapper);
        }

        [HttpPost("register-loan")]
        public ActionResult<LoanResponseDTO> RegisterNewLoan(LoanRequestDTO loanRequest)
        {

            Loan loanEntity = _dtoHelper.BuildLoanRequest(loanRequest);
            Loan registredLoan = _IloanUseCase.CreateLoan(loanEntity);
            LoanResponseDTO loanResponse = _dtoHelper.EntityToDto(registredLoan);
            return new ActionResult<LoanResponseDTO>(loanResponse);
        }




    }
}
