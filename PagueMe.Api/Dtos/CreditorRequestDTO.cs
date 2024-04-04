using System.Text.Json.Serialization;

namespace Pagame.Api.Dtos
{
    public class CreditorRequestDTO
    {
        [JsonPropertyName("nome")]
        public string Name { get; set; }
        [JsonPropertyName("cpf")]
        public string IdentityNumber { get; set; }
        [JsonPropertyName("senha")]
        public string Password { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
