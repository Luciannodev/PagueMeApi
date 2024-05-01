using AutoMapper;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Dtos.Response;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Querys;

namespace PagueMe.Api.Mapper
{
    public static class DtoToEntityHelper
    {
        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DtoMapper>();
        }).CreateMapper();

        public static Loan BuildLoanRequest(LoanRegisterRequestDTO loanRequest)
        {
            Loan loanEntity = LoanDtoToEntity(loanRequest);
            loanEntity.Debtor = new Debtor() { Name = loanRequest.Name };
            return loanEntity;
        }

        public static Loan LoanDtoToEntity(LoanRegisterRequestDTO loanRequest)
        {
            return _mapper.Map<Loan>(loanRequest);
        }

        public static Creditor CreditorDtoToEntity(CreditorRequestDTO creditorRequestDTO)
        {
            return _mapper.Map<Creditor>(creditorRequestDTO);
        }

        public static LoanResponseDTO LoanEntityToDto(Loan loan)
        {
            return _mapper.Map<LoanResponseDTO>(loan);
        }

        public static Loan LoanDtoToEntity(LoanUpdateRequestDTO loanRequest)
        {
            return _mapper.Map<Loan>(loanRequest);
        }

        public static Loan ListLoanDtoToEntity(GetLoanQuery getLoanQuery)
        {
            return _mapper.Map<Loan>(getLoanQuery);
        }

        public static ListLoanQuery BuildGetLoanQuery(GetLoanQuery getLoanQuery)
        {
            return new ListLoanQuery
            {
                LoanId = getLoanQuery.LoanId,
                TotalValue = getLoanQuery.TotalValue,
                LoanValue = getLoanQuery.LoanValue,
                PaymentStatus = getLoanQuery.PaymentStatus,
                IdentifyNumber = getLoanQuery.IdentifyNumber,
                DueDate = getLoanQuery.DueDate
            };
        }
    }
}
