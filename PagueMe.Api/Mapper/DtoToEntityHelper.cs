using AutoMapper;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Dtos.Response;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Mapper
{
    public static class DtoToEntityHelper
    {
        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DtoMapper>();
        }).CreateMapper();

        public static Loan BuildLoanRequest(LoanRequestDTO loanRequest)
        {
            Loan loanEntity = DtoToEntity(loanRequest);
            loanEntity.Debtor = new Debtor() { Name = loanRequest.Name };
            return loanEntity;
        }

        private static Loan DtoToEntity(LoanRequestDTO loanRequest)
        {
            return _mapper.Map<Loan>(loanRequest);
        }

        public static Creditor DtoToEntity(CreditorRequestDTO creditorRequestDTO)
        {
            return _mapper.Map<Creditor>(creditorRequestDTO);
        }

        public static LoanResponseDTO EntityToDto(Loan loan)
        {
            return _mapper.Map<LoanResponseDTO>(loan);
        }
    }
}
