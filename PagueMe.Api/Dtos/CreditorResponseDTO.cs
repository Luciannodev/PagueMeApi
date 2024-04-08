using PagueMe.Domain.Entities;

namespace PagueMe.Api.Dtos
{
    public class CreditorResponseDTO
    {
        public int CreditorId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
    }
}
