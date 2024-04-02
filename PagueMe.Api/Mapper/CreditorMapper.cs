using Pagame.Api.Dtos;
using PagueMe.Domain.Entities;

namespace Pagame.Api.Mapper
{
    public class CreditorMapper
    {
        public static Creditor DtoToEntity(CreditorRequestDTO creditorRequestDTO)
        {
            Creditor creditor = new Creditor(creditorRequestDTO.name, 0, creditorRequestDTO.identity_number, creditorRequestDTO.password, creditorRequestDTO.email,new List<Loan>());
            return creditor; 
        }
    }
}
