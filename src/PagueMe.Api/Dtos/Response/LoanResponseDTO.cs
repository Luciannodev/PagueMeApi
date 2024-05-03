using System.Text.Json.Serialization;

namespace PagueMe.Api.Dtos.Response
{
    public class LoanResponseDTO
    {
        [JsonPropertyName("id")]
        public int LoanId { get; set; }
        [JsonPropertyName("cliente")]
        public string Name { get; set; }
        [JsonPropertyName("data_prevista_pagamento")]
        public DateTime DueDate { get; set; }
        [JsonPropertyName("valor_emprestimo")]
        public float LoanValue { get; set; }
        [JsonPropertyName("parcelamento")]
        public List<InstallmentResponseDTO> Installment { get; set; }
        [JsonPropertyName("juros")]
        public float Interest { get; set; }
        [JsonPropertyName("valor_recebido_previsto")]
        public float TotalValue { get; set; }

    }
}