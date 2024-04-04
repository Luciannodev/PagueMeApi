using AutoMapper;
using Pagame.Api.Dtos;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Mapper
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity() {
        CreateMap<CreditorRequestDTO,Creditor>().ReverseMap();
        }    
    }
}
