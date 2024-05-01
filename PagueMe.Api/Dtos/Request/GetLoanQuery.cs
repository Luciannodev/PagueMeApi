using Microsoft.AspNetCore.Mvc;

namespace PagueMe.Api.Dtos.Request
{
    public class GetLoanQuery
    {
        [FromQuery(Name = "loan_id")]
        public int? LoanId { get; set; }
        [FromQuery(Name = "valor_total")]
        public float ?TotalValue { get; set; }
        [FromQuery(Name = "valor_emprestimo")]
        public float ?LoanValue { get; set; }
        [FromQuery(Name = "status_pagamento")]
        public int ?PaymentStatus { get; set; }
        [FromQuery(Name = "cpf")]
        public string ?IdentifyNumber { get; set; }
        [FromQuery(Name = "data_vencimento")]
        public string ?DueDate { get; set; }
    }
}
