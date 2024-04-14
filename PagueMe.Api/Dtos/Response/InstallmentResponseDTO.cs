using System.Text.Json.Serialization;

namespace PagueMe.Api.Dtos.Response
{
    public class InstallmentResponseDTO
    {
        [JsonPropertyName("ordem_pagamento")]
        public int InstallmentsOrder { get; set; }
        [JsonPropertyName("data_vencimento")]
        public DateTime DueDate { get; set; }
        [JsonPropertyName("valor")]
        public float Value { get; set; }
    }
}