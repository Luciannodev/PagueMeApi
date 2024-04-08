using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Pagame.Api.Dtos;
using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace PagueMe.Api.Controllers
{

    [ApiController]
    public class LoanController(ILoanUseCase iLoanUseCase, IMapper mapper) : ControllerBase
    {

        private readonly ILoanUseCase _ILoanUseCase = iLoanUseCase;
        private readonly IMapper _Mapper = mapper;

        [HttpPost("register-loan")]
        public ActionResult<Loan> RegisterNewLoan(LoanRequestDTO loanRequest)
        {
            Loan loanEntity = BuildRequest(loanRequest);
            Loan registredLoan = _ILoanUseCase.CreateLoan(loanEntity);
            return new ActionResult<Loan>(registredLoan);
        }

        private Loan BuildRequest(LoanRequestDTO loanRequest)
        {
            loanRequest.IdentityNumber = getIdentifyNumber();
            Loan loanEntity = _Mapper.Map<Loan>(loanRequest);
            loanEntity.Debtor = new Debtor() { Name = loanRequest.Name };
            return loanEntity;
        }

        private string getIdentifyNumber()
        {
            Request.Headers.TryGetValue("Authorization", out StringValues headerValue);
            string jwtEncoded = headerValue.ToString().Substring(7);
            var token = new JwtSecurityToken(jwtEncoded);
            var cpf = token.Claims.First(c => c.Type == "cpf").Value;
            return cpf;
        }
    }
}
