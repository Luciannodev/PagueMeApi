using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace PagueMe.Application.UseCase
{
    public class LoanUseCase : ILoanUseCase
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ICreditorUseCase _creditorUseCase;
        private readonly HttpRequest _httpRequest;

        public LoanUseCase(ILoanRepository loanRepository, ICreditorUseCase creditorUseCase, IHttpContextAccessor httpRequest)
        {
            _httpRequest = httpRequest.HttpContext.Request;
            _loanRepository = loanRepository;
            _creditorUseCase = creditorUseCase;
        }

        public Loan CreateLoan(Loan loan)
        {
            Creditor creditor = _creditorUseCase.AddValueCreditor(loan.TotalValue, GetIdentifyNumber());
            loan.Creditor = creditor;
            return _loanRepository.CreateLoan(loan);


        }

        public string GetIdentifyNumber()
        {
            _httpRequest.Headers.TryGetValue("Authorization", out StringValues headerValue);
            string jwtEncoded = headerValue.ToString().Substring(7);
            var token = new JwtSecurityToken(jwtEncoded);
            var cpf = token.Claims.First(c => c.Type == "cpf").Value;
            return cpf;
        }

        public Loan LoanPayment(Loan request)
        {
            throw new NotImplementedException();
        }
    }
}
