using System.Text.Json.Serialization;

namespace PagueMe.Api.Dtos.Request
{
    public class InstallmentDTO
    {
        [JsonPropertyName("ordem_pagamento")]
        public int InstallmentsOrder { get; set; }
        [JsonPropertyName("data_vencimento")]
        public required string DueDate { get; set; }
        [JsonPropertyName("valor")]
        public float Value { get; set; }
        public int PaymentStatus { get; set; } = 1;
    }
}
