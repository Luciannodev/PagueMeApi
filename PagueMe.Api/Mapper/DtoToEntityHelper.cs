using AutoMapper;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Dtos.Response;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Mapper
{
    public class DtoToEntityHelper(IMapper mapper)
    {
        private readonly IMapper _mapper = mapper;

        public Loan BuildLoanRequest(LoanRequestDTO loanRequest)
        {
            Loan loanEntity = DtoToEntity(loanRequest);
            loanEntity.Debtor = new Debtor() { Name = loanRequest.Name };
            return loanEntity;
        }

        private Loan DtoToEntity(LoanRequestDTO loanRequest)
        {
            return _mapper.Map<Loan>(loanRequest);
        }

        public Creditor DtoToEntity(CreditorRequestDTO creditorRequestDTO)
        {
            return _mapper.Map<Creditor>(creditorRequestDTO);
        }

        public LoanResponseDTO EntityToDto(Loan loan)
        {
            return _mapper.Map<LoanResponseDTO>(loan);
        }
    }
}
