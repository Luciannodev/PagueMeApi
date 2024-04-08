﻿using PagueMe.Domain.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pagame.Api.Dtos
{
    public class LoanRequestDTO
    {

        [JsonPropertyName("nome")]
        public required string Name { get; set; }
        [JsonPropertyName("data_prevista_pagamento")]
        public required string DueDate { get; set; }
        [JsonPropertyName("valor_emprestimo")]
        public required float LoanValue { get; set; }
        [JsonPropertyName("parcelamento")]
        public required List<InstallmentDTO> Installment { get; set; }
        [JsonPropertyName("juros")]
        public required float Interest { get; set; }
        [JsonPropertyName("valor_total")]
        public required int TotalValue { get; set; }

        public int PaymentStatus { get; set; } = 1;

        public string ?IdentityNumber { get; set; }
    }


}
