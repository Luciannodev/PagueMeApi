using PagueMe.Api.Dtos.Vallidators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pagame.Api.Dtos
{
    public class CreditorRequestDTO
    {
        [JsonPropertyName("nome")]
        [Required(ErrorMessage = "É Necessario preencher o nome!")]
        public string  Name { get; set; }
        [JsonPropertyName("cpf")]
        [Required(ErrorMessage = "É Necessario preencher o CPF!")]
        public string IdentityNumber { get; set; }
        [JsonPropertyName("senha")]
        [Required(ErrorMessage = "É Necessario preencher a senha!")]
        public string Password { get; set; }
        [JsonPropertyName("email")]
        [Required(ErrorMessage = "É Necessario preencher Email!")]
        public string Email { get; set; }
    }
}
