namespace PagueMe.Domain.Querys
{
    public class ListLoanQuery
    {
        public int? LoanId { get; set; }
        public float? TotalValue { get; set; }
        public float? LoanValue { get; set; }
        public int? PaymentStatus { get; set; }
        public string? IdentifyNumber { get; set; }
        public string? DueDate { get; set; }
    }
}
