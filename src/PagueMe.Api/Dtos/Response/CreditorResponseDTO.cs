using PagueMe.Domain.Entities;

namespace PagueMe.Api.Dtos.Response
{
    public class CreditorResponseDTO
    {
        public int CreditorId { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
    }
}
