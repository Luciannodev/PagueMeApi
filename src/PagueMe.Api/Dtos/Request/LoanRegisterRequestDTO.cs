using System.Text.Json.Serialization;

namespace PagueMe.Api.Dtos.Request
{
    public class LoanRegisterRequestDTO
    {
        [JsonPropertyName("id")]
        public int LoanId { get; set; }
        [JsonPropertyName("nome")]
        public required string Name { get; set; }
        [JsonPropertyName("data_prevista_pagamento")]
        public required string DueDate { get; set; }
        [JsonPropertyName("valor_emprestimo")]
        public required float LoanValue { get; set; }
        [JsonPropertyName("parcelamento")]
        public List<InstallmentDTO>? Installment { get; set; }
        [JsonPropertyName("juros")]
        public required float Interest { get; set; }
        [JsonPropertyName("valor_total")]
        public required int TotalValue { get; set; }

        public int PaymentStatus { get; set; } = 1;

        public string? IdentityNumber { get; set; }


    }


}
