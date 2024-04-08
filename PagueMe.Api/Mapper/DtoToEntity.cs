using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Pagame.Api.Dtos;
using PagueMe.Domain.Entities;
using System.Globalization;

namespace PagueMe.Api.Mapper
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<CreditorRequestDTO, Creditor>().ReverseMap();
            CreateMap<LoanRequestDTO, Loan>().
            ForMember(destinationMember: x => x.DueDate,
                    memberOptions: opt => opt.MapFrom(x => DateTime.Parse(x.DueDate, new CultureInfo("pt-BR")))).
                ReverseMap();
            CreateMap<InstallmentDTO, Installment>().ReverseMap();
        }
    }
}
