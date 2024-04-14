using AutoMapper;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Dtos.Response;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Mapper
{
    public class DtoToEntityHelper
    {
        private readonly IMapper _Mapper;

        public DtoToEntityHelper(IMapper mapper)
        {
            _Mapper = mapper;

        }
        public Loan BuildRequest(LoanRequestDTO loanRequest)
        {
            Loan loanEntity = DtoToEntity(loanRequest);
            loanEntity.Debtor = new Debtor() { Name = loanRequest.Name };
            return loanEntity;
        }

        private Loan DtoToEntity(LoanRequestDTO loanRequest)
        {
            return _Mapper.Map<Loan>(loanRequest);
        }

        public Creditor DtoToEntity(CreditorRequestDTO creditorRequestDTO)
        {
            return _Mapper.Map<Creditor>(creditorRequestDTO);
        }

        public LoanResponseDTO EntityToDto(Loan loan)
        {
            return _Mapper.Map<LoanResponseDTO>(loan);
        }
    }
}
