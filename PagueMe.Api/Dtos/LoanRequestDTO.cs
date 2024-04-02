using PagueMe.Domain.Entities;
using System.Collections.Generic;

namespace Pagame.Api.Dtos
{
    public class LoanRequestDTO
    {
        public readonly List<Installment> Installments;

        public required string Name { get; set; }
        public required string DueDate { get; set; }
        public required int LoanValue { get; set; }
        public required List<InstallmentDTO> Installment { get; set; }
        public required float Interest { get; set; }
        public required int TotalValue { get; set; }

        public required string IdentityNumber { get; set; }
    }


}
