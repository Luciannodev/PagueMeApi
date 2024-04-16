using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Interface.Repositories;
using PagueMe.Domain.Interface.Security;
using System.IdentityModel.Tokens.Jwt;

namespace PagueMe.Infra.ExternalServices.Security
{
    public class Account : IAccount
    {
        private readonly ICreditorRepository _repository;
        private readonly HttpRequest _httpRequest;

        public Account(ICreditorRepository repository, IHttpContextAccessor httpRequest)
        {
            _repository = repository;
            _httpRequest = httpRequest.HttpContext.Request;
        }

        public bool PasswordIsValid(string password)
        {
            Creditor creditor = _repository.GetCreditorByIdentityNumber(GetIdentityNumber());
            bool v = HashHelper.CheckPassword(password, creditor.Password);
            throw new NotImplementedException();
        }

        public string GetIdentityNumber()
        {
            JwtSecurityToken token = GetJwt();
            var cpf = token.Claims.First(c => c.Type == "cpf").Value;
            return cpf;
        }
        private JwtSecurityToken GetJwt()
        {
            _httpRequest.Headers.TryGetValue("Authorization", out StringValues headerValue);
            string jwtEncoded = headerValue.ToString().Substring(7);
            var token = new JwtSecurityToken(jwtEncoded);
            return token;
        }
    }
}
