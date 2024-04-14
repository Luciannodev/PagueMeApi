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
            CreateMap<CreditorRequestDTO, Creditor>().ReverseMap();
            CreateMap<LoanRequestDTO, Loan>().
            ForMember(destinationMember: x => x.DueDate,
                    memberOptions: opt => opt.MapFrom(x => DateTime.Parse(x.DueDate, new CultureInfo("pt-BR")))).
                ReverseMap();
            CreateMap<InstallmentDTO, Installment>()
                .ReverseMap();

            CreateMap<LoanResponseDTO, Loan>()
                .ForPath(dest => dest.Debtor.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
            CreateMap<InstallmentResponseDTO,Installment>()
                .ReverseMap();
        }
    }
}
