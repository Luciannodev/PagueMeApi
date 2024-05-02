using AutoMapper;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Dtos.Response;
using PagueMe.Domain.Entities;
using System.Globalization;

namespace PagueMe.Api.Mapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            RequestsMappers();
            ResponseMappers();
        }

        private void RequestsMappers()
        {
            CreateMap<CreditorRequestDTO, Creditor>().ReverseMap();

            CreateMap<LoanRegisterRequestDTO, Loan>().
            ForMember(destinationMember: x => x.DueDate,
                    memberOptions: opt => opt.MapFrom(x => DateTime.Parse(x.DueDate, new CultureInfo("pt-BR"))))
                .ReverseMap();

            CreateMap<LoanUpdateRequestDTO, Loan>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => DateTime.Parse(src.DueDate, new CultureInfo("pt-BR"))))
                .ForPath(dest => dest.Debtor.Name, opt => opt.MapFrom(src => src.name))
                .ReverseMap();

            CreateMap<InstallmentDTO, Installment>()
                .ReverseMap();

            CreateMap<GetLoanQuery, Loan>()
                .ReverseMap();
        }

        private void ResponseMappers()
        {
            CreateMap<LoanResponseDTO, Loan>()
                .ForPath(dest => dest.Debtor.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<InstallmentResponseDTO, Installment>()
                .ReverseMap();
        }


    }
}
