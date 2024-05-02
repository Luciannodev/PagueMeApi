using System.Text.Json.Serialization;

namespace PagueMe.Api.Dtos.Request
{
    public class LoanUpdateRequestDTO
    {
        [JsonPropertyName("id")]
        public int ?LoanId { get; set; }
        [JsonPropertyName("nome")]
        public string ?name { get; set; }
        [JsonPropertyName("data_prevista_pagamento")]
        public string ?DueDate { get; set; }
        [JsonPropertyName("valor_emprestimo")]
        public float ?LoanValue { get; set; }
        [JsonPropertyName("juros")]
        public float ?Interest { get; set; }
        [JsonPropertyName("credor_id")]
        public int ?CreditorId { get; set; }
        [JsonPropertyName("debtor_id")]
        public int ?DebtorId { get; set; }
        [JsonPropertyName("valor_total")]
        public float ?TotalValue { get; set; }

    }
}
